using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using Verse;

namespace StrangePills
{
    public class RandomEffect_HealerSerum : RandomEffect
    {
        public override bool TryDoEffect(Pawn pawn)
        {
			TaggedString taggedString = HealthUtility.FixWorstHealthCondition(pawn);
			if (taggedString != null)
            {
                return true;
            }
            return false;
		}
    }
}
