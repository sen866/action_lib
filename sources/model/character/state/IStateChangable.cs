using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.character.state
{
    public delegate void StateChangableEvent(IStateChangable stateChangable);

    public interface IStateChangable
    {
        IState CurrentState { get; }

        event StateChangableEvent OnChangeState;
        event StateChangableEvent OnStateEnd;

        bool ChangeState(IState state);

        bool CanMove();

        void updateNextState(float now);
    }
}
