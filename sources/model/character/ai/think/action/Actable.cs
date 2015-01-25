using action_game.sources.model.character.ai.think.state;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.character.ai.think.action
{
    public interface Actable
    {
        IState Do(ICharacterable own, float now, float deltaTime);
    }
}
