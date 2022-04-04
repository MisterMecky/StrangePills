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
        public static void GetWeightedGrade<T>(this List<StrangeEffectDef> source, out StrangeEffectDef effect)
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
                    //Log.Message(item.defName + "Added");
                    list.Add(item);
                }
            }
            effect = list.RandomElement();
        }
    }
}
