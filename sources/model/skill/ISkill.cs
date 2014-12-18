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

        void Execute(ICharacterable executor);

        event Action<ICharacterable> OnExecute;
    }
}
