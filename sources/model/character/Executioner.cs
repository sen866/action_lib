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
        public bool ExecuteNormal(float now, ICharacterable characterable)
        {
            var skill = characterable.SkillHolder.Current;

            if (null == skill)
            {
                return false;
            }

            if (characterable.BattleCharacter.Stamina.Current < skill.GetNeedToUseStamina())
            {
                return false;
            }

            var finishState = new SkillExecuteFinish();

            finishState.OnStart += delegate(ICharacterable dummy) { characterable.SkillHolder.ResetCurrent(); };

            if (!characterable.ChangeState(
                new SkillExecuting(
                    now,
                    skill.GetExecutingTime() - skill.GetChainTime(),
                    new NextSkillChainChance(
                        now,
                        skill.GetExecutingTime() + skill.GetChainTime(),
                        new SkillRecasting(
                            now,
                            skill.GetExecutingTime() + skill.GetRecastingTime(),
                            finishState
                            )
                        )
                    )
                ))
            {
                return false;
            }

            //  実行
            skill.Execute(characterable);

            characterable.SkillHolder.MoveNextNormal();

            return true;
        }
    }
}
