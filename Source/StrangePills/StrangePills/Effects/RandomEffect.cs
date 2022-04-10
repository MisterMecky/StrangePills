using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using Verse;

namespace StrangePills
{
    public abstract class RandomEffect
    {
        public abstract bool TryDoEffect(Pawn pawn);
    }
}
