using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using Verse;

namespace StrangePills
{
    public class RandomEffect_MentalState : RandomEffect
    {
        public override bool TryDoEffect(Pawn pawn)
        {
            if (pawn.mindState.mentalStateHandler.TryStartMentalState(mentalState))
            {
                return true;
            }
            return false;
        }

        MentalStateDef mentalState;
    }
}
