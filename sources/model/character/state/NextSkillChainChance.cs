using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.character.state
{
    class NextSkillChainChance : IState
    {
        public NextSkillChainChance(float now, float stateTime, IState nextState)
        {
            this.startTime = now;
            this.stateTime = stateTime;
            this.nextState = nextState;
        }

        public State GetState() { return State.NextSkillChainChance;  }

        public bool IsToChangable(IState state)
        {
            return true;
        }

        public bool IsFromChangable(IState state)
        {
            return state.GetState() == State.SkillExecuting;
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
            return now - startTime > stateTime;
        }

        public IState GetNextState()
        {
            return nextState;
        }

        private float startTime { get; set; }
        private float stateTime { get; set; }
        private IState nextState { get; set; }

        public void Enter(ICharacterable characterable)
        {
            if (null != OnStart)
                OnStart(characterable);

            OnStart = null;
        }

        public void Exit(ICharacterable characterable)
        {
            if (null != OnEnd)
                OnEnd(characterable);

            OnEnd = null;
        }

        public event Action<ICharacterable> OnStart;

        public event Action<ICharacterable> OnEnd;
    }
}
