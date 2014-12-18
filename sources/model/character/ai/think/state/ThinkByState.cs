using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using action_game.sources.model.character.ai.think.state;

namespace action_game.sources.model.character.ai.think.state
{
    class ThinkByState : IThinkable
    {
        public ThinkByState()
        {
            state = new Wait();
        }

        public void Update(ICharacterable own, float now, float deltaTime)
        {
            state = state.Update(own, now, deltaTime);
        }

        private IState state { get; set; }
    }
}
