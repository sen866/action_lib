using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.character.ai.think.state
{
    interface IState
    {
        IState Update(ICharacterable own, float now, float deltaTime);
    }
}
