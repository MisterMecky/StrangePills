﻿using System;
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
        public RandomGrade randomGrade = RandomGrade.VeryBad;
        public int weight;
        public bool canEffectAnimals = false;
        public bool canEffectHumanoids = true;
        public RandomEffect randomEffect;

        public RandomGrade GetGrade() { return randomGrade; }
    }
}