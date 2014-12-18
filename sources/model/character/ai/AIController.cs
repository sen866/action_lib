using action_game.sources.model.character.ai.think;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.character.ai
{
    public class AIController
    {
        public AIController(IThinkable _thinkable)
        {
            thinkable = _thinkable;
        }

        public void Update(ICharacterable own, float now, float deltaTime)
        {
            thinkable.Update(own, now, deltaTime);
        }

        private IThinkable thinkable { get; set; }
    }
}
