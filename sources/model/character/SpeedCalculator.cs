using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.character
{
    class SpeedCalculator
    {
        public static float Calculate(float basicSpeed, ICharacterable characterable)
        {
            return basicSpeed + characterable.PickupItemHolder.GetRunMaxSpeed();
        }
    }
}
