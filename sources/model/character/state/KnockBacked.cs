using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.character.state
{
    class KnockBacked : IState
    {
        public KnockBacked(float stateTime, Vector distance)
        {
            this.startTime = 0.0f;
            this.stateTime = stateTime;
            this.velocity = distance / stateTime;
        }

        public State GetState()
        {
            return State.KnockBacked;
        }

        public bool IsToChangable(IState state)
        {
            return state.GetState() == State.Idle || state.GetState() == State.KnockBacked;
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
            if (startTime <= 0.0f)
            {
                startTime = now;
            }

            return now - startTime > stateTime;
        }

        public IState GetNextState()
        {
            return new Idle();
        }

        public void Enter(ICharacterable characterable)
        {
            characterable.SetVelocity(velocity.x, velocity.y, velocity.z);

            OnStart(characterable);
        }

        public void Exit(ICharacterable characterable)
        {
            characterable.SetVelocity(0.0f, 0.0f, 0.0f);

            characterable.SkillHolder.ResetCurrent();

            OnEnd(characterable);
        }

        private float startTime { get; set; }
        private float stateTime { get; set; }

        private Vector velocity { get; set; }

        public event Action<ICharacterable> OnStart = delegate { };

        public event Action<ICharacterable> OnEnd = delegate { };
    }
}
