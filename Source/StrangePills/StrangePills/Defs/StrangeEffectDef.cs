using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using Verse;

namespace StrangePills
{
    public class StrangeEffectDef : Def
    {
        public RandomGrade randomGrade;
        public int weight;
        public bool canEffectAnimals = false;
        public bool canEffectHumanoids = true;
    }
}
