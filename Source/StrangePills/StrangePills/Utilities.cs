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
        public static void DoRandomOutcome<T>(this List<StrangeEffectDef> source, Pawn pawn)
        {
            if (pawn.RaceProps.Humanlike)
            {
                source = DefDatabase<StrangeEffectDef>.AllDefs.Where((StrangeEffectDef def) => def.canEffectHumanoids = true && def.randomGrade == GetRandomGrade()).ToList();
                IterateRandomOutcome(source, pawn);
            }
            else if (pawn.RaceProps.Animal)
            {
                source = DefDatabase<StrangeEffectDef>.AllDefs.Where((StrangeEffectDef def) => def.canEffectAnimals = true && def.randomGrade == GetRandomGrade()).ToList();
                IterateRandomOutcome(source, pawn);
            }
            
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
                        strangeEffect.SuccessMessage();
                    }
                    else
                    {
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
                throw new NotImplementedException();
            }
        }
        
        public static RandomGrade GetRandomGrade()
        {
            Random rnd = new Random();
            int randNum = rnd.Next(1, 11);
            if (randNum == 1)
            {
                return RandomGrade.VeryBad;
            }
            else if (randNum <= 3)
            {
                return RandomGrade.Bad;
            }
            else if (randNum <= 7)
            {
                return RandomGrade.Neutral;
            }
            else if (randNum <= 9)
            {
                return RandomGrade.Good;
            }
            else
            {
                return RandomGrade.VeryGood;
            }
        }
        public static void DoRandomEffect<T>(this List<StrangeEffectDef> source, out StrangeEffectDef effect)
        {
            RandomGrade grade;
            Random rnd = new Random();
            int randNum = rnd.Next(1, 11);
            if (randNum == 1)
            {
                grade = RandomGrade.VeryBad;
            }
            else if (randNum <= 3)
            {
                grade = RandomGrade.Bad;
            }
            else if (randNum <= 7)
            {
                grade = RandomGrade.Neutral;
            }
            else if (randNum <= 9)
            {
                grade = RandomGrade.Good;
            }
            else
            {
                grade = RandomGrade.VeryGood;
            }
            List<StrangeEffectDef> list = new List<StrangeEffectDef>();
            foreach(var item in source)
            {
                if (item.randomGrade == grade)
                {
                    list.Add(item);
                }
            }
            effect = list.RandomElement();
        }
    }
}
