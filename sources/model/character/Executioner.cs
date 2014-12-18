using action_game.sources.model.character.state;
using action_game.sources.model.skill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.character
{
    public class Executioner : ISkillExecutable
    {
        public void execute(float now, ICharacterable characterable, ISkill skill)
        {
            if (!characterable.ChangeState(
                new SkillExecuting(now, skill.GetExecutingTime(), new Idle())
                ))
            {
                return;
            }

            //  実行
            skill.Execute(characterable);
        }
    }
}
