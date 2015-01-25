using action_game.sources.model.character.ai.think.action;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.character.ai.think
{
    public interface IThinkable
    {
        Actable ThinkNext(ICharacterable own, float now, float deltaTime);

        void Update(ICharacterable own, float now, float deltaTime);
    }
}
