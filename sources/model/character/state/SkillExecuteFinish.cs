using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.character.state
{
    class SkillExecuteFinish : IState
    {
        public State GetState()
        {
            return State.SkillExecuteFinish;
        }

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
            return false;
        }

        public bool CanAttack()
        {
            return false;
        }

        public bool IsNextStateTime(float now)
        {
            return true;
        }

        public IState GetNextState()
        {
            return new Idle();
        }

        public void Enter()
        {
            OnStart();
        }

        public void Exit()
        {
            OnEnd();
        }

        public event Action OnStart = delegate { };

        public event Action OnEnd = delegate { };
    }
}
