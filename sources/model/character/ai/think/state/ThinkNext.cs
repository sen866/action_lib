using action_game.sources.model.character.group;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.character.ai.think.state
{
    //  次何をするか考える状態
    class ThinkNext : IState
    {
        public IState Update(IThinkable parent, ICharacterable own, float now, float deltaTime)
        {
            var actable = parent.ThinkNext(own, now, deltaTime);

            return actable.Do(own, now, deltaTime);
        }
    }
}
