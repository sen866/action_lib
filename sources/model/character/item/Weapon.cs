using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.character.item
{
    public class Weapon : IEquipable
    {
        public Weapon(BattleStatus status)
        {
            BattleStatus = status;
        }
        public BattleStatus BattleStatus { get; set; }
    }
}
