using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.character.item
{
    public class PickupItemHolder
    {
        public PickupItemHolder()
        {
            pickupItems = new List<PickupItem>();
        }

        public BattleStatus GetBattleStatus()
        {
            BattleStatus result = new BattleStatus();

            pickupItems.ForEach(
                _ => result += _.GetBattleStatus()
                );

            return result;
        }

        public float GetRunMaxSpeed()
        {
            float result = 0.0f;

            pickupItems.ForEach(
                _ => result += _.GetRunMaxSpeed()
                );

            return result;
        }

        public void Add(PickupItem item)
        {
            pickupItems.Add(item);

            OnPickedItem();
        }

        List<PickupItem> pickupItems;

        public event Action OnPickedItem = delegate { };
    }
}
