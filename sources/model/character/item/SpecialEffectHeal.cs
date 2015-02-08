using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.character.item
{
    public class SpecialEffectHeal : ISpecialEffectable
    {
        public SpecialEffectHeal(float _healValue)
        {
            healValue = _healValue;
        }

        public void PickedEffect(ICharacterable characterable)
        {
            characterable.BattleCharacter.Healed(healValue);
        }

        private float healValue { get; set; }
    }
}
