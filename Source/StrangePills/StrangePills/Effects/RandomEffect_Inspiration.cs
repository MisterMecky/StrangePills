using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using Verse;

namespace StrangePills
{
    public class RandomEffect_Inspiration : RandomEffect
    {
  //      public override void DoEffect(Pawn pawn)
  //      {
			
		//}

        public override bool TryDoEffect(Pawn pawn)
        {
            if (pawn.mindState.inspirationHandler.TryStartInspiration(inspiration))
            {
                return true;
            }
            return false;
        }

        InspirationDef inspiration;
    }
}
