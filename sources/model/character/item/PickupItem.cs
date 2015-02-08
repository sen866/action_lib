using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.character.item
{
    public class PickupItem : IStatusChangable
    {
        public PickupItem(BattleStatus _status, float _speed, List<ISpecialEffectable> effects)
        {
            status = _status;
            speed = _speed;
            Effects = effects;
        }

        public BattleStatus GetBattleStatus()
        {
            return status;
        }


        public float GetRunMaxSpeed()
        {
            return speed;
        }

        private BattleStatus status { get; set; }

        private float speed { get; set; }

        public List<ISpecialEffectable> Effects { get; set; }
    }
}
