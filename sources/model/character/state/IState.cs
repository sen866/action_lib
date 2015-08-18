using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.character.state
{
    public enum State
    {
        Idle,
        SkillExecuting,
        NextSkillChainChance,
        SkillRecasting,
        SkillExecuteFinish,
        KnockBacked,
    }

    public interface IState
    {
        State GetState();
        bool IsToChangable(IState state);
        bool IsFromChangable(IState state);
        bool CanMove();
        bool CanAttack();
        bool IsNextStateTime(float now);
        IState GetNextState();
        void Enter(ICharacterable characterable);
        void Exit(ICharacterable characterable);

        event Action<ICharacterable> OnStart;
        event Action<ICharacterable> OnEnd;
    }
}
