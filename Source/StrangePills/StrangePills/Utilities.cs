using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using Verse;

namespace StrangePills
{
    public static class Utilities
    {
        public static (RandomGrade, float)[] gradeList = new[]
        {
            (RandomGrade.VeryBad, 1.0f),
            (RandomGrade.Bad, 2.0f),
            (RandomGrade.Neutral, 4.0f),
            (RandomGrade.Good, 2.0f),
            (RandomGrade.VeryGood, 1.0f)
        };

        public static void DoRandomOutcome(Pawn pawn)
        {
            List<StrangeEffectDef> source = null;
            RandomGrade grade = GetRandomGrade<RandomGrade>(gradeList);
            if (pawn.RaceProps.Humanlike)
            {
                source = DefDatabase<StrangeEffectDef>.AllDefs.Where((StrangeEffectDef def) => def.canEffectHumanoids == true).ToList();
            }
            else if (pawn.RaceProps.Animal)
            {
                source = DefDatabase<StrangeEffectDef>.AllDefs.Where((StrangeEffectDef def) => def.canEffectAnimals == true).ToList();
            }
            if (grade != RandomGrade.Undefined)
            {
                source = source.Where((StrangeEffectDef def) => def.randomGrade == grade).ToList();
            }
            IterateRandomOutcome(source, pawn);
        }

        public static void IterateRandomOutcome(List<StrangeEffectDef> source, Pawn pawn)
        {
            if (source.Count > 0)
            {
                StrangeEffectDef strangeEffect = source.RandomElementByWeight((StrangeEffectDef def) => def.weight);
                if (strangeEffect.randomEffects != null)
                {
                    int count = 0;
                    for (int i = 0; i < strangeEffect.randomEffects.Count; i++)
                    {
                        if (strangeEffect.randomEffects[i].TryDoEffect(pawn))
                        {
                            count++;
                        }
                    }
                    if (count > 0)
                    {
                        strangeEffect.SuccessMessage(pawn);
                    }
                    else
                    {
                        if (source.Remove(strangeEffect))
                        {
                            Log.Message("Removed " + strangeEffect.defName);
                            IterateRandomOutcome(source, pawn);
                        }
                        else
                        {
                            Log.Error("Could not remove " + strangeEffect.defName + " from list");
                        }
                    }
                }
                else
                {
                    Log.Warning(strangeEffect.defName + " had no random effect attached to it");
                    if (source.Remove(strangeEffect))
                    {
                        IterateRandomOutcome(source, pawn);
                    }
                    else
                    {
                        Log.Error("Could not remove " + strangeEffect.defName + " from list");
                    }
                    
                }
            }
            else
            {
                Log.Message("No effect found.");
            }
        }


        //https://codereview.stackexchange.com/questions/167195/picking-weighed-enumerable-values-at-random
        public static RandomGrade GetRandomGrade<T>((RandomGrade grade, float weight)[] odds)
        {
            float totalOdds = 0;
            foreach(var odd in odds)
            {
                totalOdds += odd.Item2;
            }
            if(totalOdds > 0)
            {
                float randomNum = Rand.Value * totalOdds;
                for (int i = 0; i < odds.Length; i++)
                {
                    randomNum -= odds[i].Item2;
                    if (randomNum <= 0)
                    {
                        return odds[i].Item1;
                    }
                }
                Log.Error("Random Grade did not find a grade");
                return RandomGrade.Undefined;
            }
            else
            {
                return RandomGrade.Undefined;
            }
        }
    }
}
