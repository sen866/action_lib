using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.character
{
    class BattleStatusCalculator
    {
        public static BattleStatus calculate(BattleStatus basicStatus, ICharacterable characterable)
        {
            return basicStatus + characterable.EquipItemHolder.GetBattleStatus() + characterable.PickupItemHolder.GetBattleStatus();
        }
    }
}
