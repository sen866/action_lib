﻿using System;
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

        public void Enter(ICharacterable characterable)
        {
            OnStart(characterable);

            OnStart = null;
        }

        public void Exit(ICharacterable characterable)
        {
            OnEnd(characterable);

            OnEnd = null;
        }

        public event Action<ICharacterable> OnStart = delegate { };

        public event Action<ICharacterable> OnEnd = delegate { };
    }
}
