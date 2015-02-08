using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.character.item
{
    public class EquipItemHolder
    {
        public EquipItemHolder(Weapon main)
        {
            this.main = main;
        }

        public BattleStatus GetBattleStatus()
        {
            BattleStatus result = new BattleStatus();

            if (main != null)
                result += main.BattleStatus;

            return result;
        }

        private Weapon main;
    }
}
