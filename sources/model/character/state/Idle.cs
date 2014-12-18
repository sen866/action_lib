using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.character.state
{
    class Idle : IState
    {
        public State GetState() { return State.Idle; }


        public bool IsToChangable(IState state)
        {
            return true;
        }


        public bool IsFromChangable(IState state)
        {
            return true;
        }

        public bool CanMove()
        {
            return true;
        }

        public bool CanAttack()
        {
            return false;
        }

        public bool IsNextStateTime(float now)
        {
            return false;
        }

        public IState GetNextState()
        {
            return this;
        }

        public void Enter()
        {
            if (null != OnStart)
                OnStart();
        }

        public void Exit()
        {
            if (null != OnEnd)
                OnEnd();
        }


        public event Action OnStart;

        public event Action OnEnd;
    }
}
