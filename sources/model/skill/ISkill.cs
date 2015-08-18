using action_game.sources.model.character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.skill
{
    public interface ISkill
    {
        float GetExecutingTime();

        float GetChainTime();

        float GetRecastingTime();

        int GetNeedToUseStamina();
        int GetUsedStamina();

        bool Execute(ICharacterable executor);

        void Effect(ICharacterable executor, ICharacterable target, Vector hitPosition);

        event Action<ICharacterable, ISkill> OnExecute;
    }
}
