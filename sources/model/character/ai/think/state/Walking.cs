using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.character.ai.think.state
{
    class Walking : IState
    {
        public Walking()
            : this(0.0f)
        {
        }

        public Walking(float _walkTime)
        {
            walkTime = _walkTime;

            elapsedTime = 0.0f;
        }

        public IState Update(ICharacterable own, float now, float deltaTime)
        {
            elapsedTime += deltaTime;

            if (elapsedTime < walkTime)
            {
                return this;
            }

            own.SetVelocity(0.0f, 0.0f, 0.0f);

            return new state.Wait(0.5f);
        }

        private float walkTime { get; set; }

        private float elapsedTime { get; set; }
    }
}
