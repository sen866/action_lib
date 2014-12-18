using action_game.sources.model.character.state;
using action_game.sources.model.skill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.character
{
    public interface ISkillExecutable
    {
        void execute(float now, ICharacterable characterable, ISkill skill);
    }
}
