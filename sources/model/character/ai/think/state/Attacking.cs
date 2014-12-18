using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.character.ai.think.state
{
    class Attacking : IState
    {
        public Attacking(ICharacterable own)
        {
            own.CurrentState.OnEnd += onExecuteEnd;
            isExecuting = true;
        }

        private void onExecuteEnd()
        {
            isExecuting = false;
        }

        private bool isExecuting { get; set; }

        public IState Update(ICharacterable own, float now, float deltaTime)
        {
            if (isExecuting)
            {
                return this;
            }

            return new state.Wait(2.0f);
        }
    }
}
