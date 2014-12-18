using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.character.ai.think.utility
{
    static class AttackableDistance
    {
        private const float ATTAKABLE_DISTANCE = 2.0f;

        public static bool checkDistance(ICharacterable own, ICharacterable target)
        {
            var distance = (own.CurrentPosition - target.CurrentPosition).Magnitude();

            return ATTAKABLE_DISTANCE >= distance;
        }
    }
}
