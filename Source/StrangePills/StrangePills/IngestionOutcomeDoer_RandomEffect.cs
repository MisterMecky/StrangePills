using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using Verse;


namespace StrangePills
{
    public class IngestionOutcomeDoer_RandomEffect : IngestionOutcomeDoer
    {
        protected override void DoIngestionOutcomeSpecial(Pawn pawn, Thing ingested)
        {
            RandomGrade grade;
            Random rnd = new Random();
            int randNum = rnd.Next(0, 101);
            if (randNum <= 10)
            {
                grade = RandomGrade.VeryBad;
            }
            else if (randNum <= 30)
            {
                grade = RandomGrade.Bad;
            }
            else if (randNum <= 70)
            {
                grade = RandomGrade.Neutral;
            }
            else if (randNum <= 90)
            {
                grade = RandomGrade.Good;
            }
            else
            { 
                grade = RandomGrade.VeryGood; 
            }
            DefDatabase<StrangeEffectDef>.AllDefs.GetGradedList(out var list, def => def.GetGrade() == grade);
            StrangeEffectDef strangeEffect = list.RandomElement();
            strangeEffect.randomEffect.DoEffect(pawn);
        }
        
        //public StrangeEffectDef strangeEffect;
    }
}
