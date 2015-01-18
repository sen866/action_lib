using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.character.state
{
    class SkillRecasting : IState
    {
        public SkillRecasting(float now, float stateTime, IState nextState)
        {
            this.startTime = now;
            this.stateTime = stateTime;
            this.nextState = nextState;
        }

        public State GetState() { return State.SkillRecasting; }

        public bool IsToChangable(IState state)
        {
            return true;
        }

        public bool IsFromChangable(IState state)
        {
            return state.GetState() == State.NextSkillChainChance;
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
