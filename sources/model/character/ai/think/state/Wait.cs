using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.character.ai.think.state
{
    //  待機中
    class Wait : IState
    {
        public Wait()
            : this(0.0f)
        {
        }

        public Wait(float _waitTime)
        {
            waitTime = _waitTime;

            elapsedTime = 0.0f;
        }

        public IState Update(IThinkable parent, ICharacterable own, float now, float deltaTime)
        {
            elapsedTime += deltaTime;

            if (elapsedTime < waitTime)
            {
                return this;
            }

            return new state.ThinkNext();
        }

        private float waitTime { get; set; }

        private float elapsedTime { get; set; }
    }
}
