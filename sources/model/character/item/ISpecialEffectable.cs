using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.character.item
{
    public interface ISpecialEffectable
    {
        void PickedEffect(ICharacterable characterable);
    }
}
