using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using Verse;

namespace StrangePills
{
    [StaticConstructorOnStartup]
    public static class MyMod
    {
        static MyMod() //our constructor
        {
            Log.Message("Hello World!"); //Outputs "Hello World!" to the dev console.
        }
    }

    public static class Utilities
    {
        
        public static void GetGradedList<T>(this IEnumerable<T> source, out List<T> list, Func<T, bool> func)
        {
            list = new List<T>();
            foreach (var item in source)
            {
                if(func(item))
                {
                    list.Add(item);
                }
            }
        }

        //public static void GetItemByWeight<T>(this IEnumerable<T> source)
        //{
        //    var def = source.RandomElement();
            
            
        //}
        
        //public static RandomGrade GetWeightedGrade()
        //{
        //    Random rnd = new Random();
        //    int randNum = rnd.Next(0, 101);
        //    if(randNum <= 10)
        //    {
        //        return RandomGrade.VeryBad;
        //    }
        //    if (randNum <= 30)
        //    {
        //        return RandomGrade.Bad;
        //    }
        //    if (randNum <= 70)
        //    {
        //        return RandomGrade.Neutral;
        //    }
        //    if (randNum <= 90)
        //    {
        //        return RandomGrade.Good;
        //    }
        //    return RandomGrade.VeryGood;
        //}
    }
}
