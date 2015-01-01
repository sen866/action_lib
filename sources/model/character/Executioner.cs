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
        public void ExecuteNormal(float now, ICharacterable characterable)
        {
            var skill = characterable.SkillHolder.Current;

            if (null == skill)
            {
                return;
            }

            var finishState = new SkillExecuteFinish();

            finishState.OnStart += characterable.SkillHolder.ResetCurrent;

            if (!characterable.ChangeState(
                new SkillExecuting(now, skill.GetExecutingTime(), finishState)
                ))
            {
                UnityEngine.Debug.Log("return");
                return;
            }

            //  実行
            skill.Execute(characterable);

            characterable.SkillHolder.MoveNextNormal();
        }
    }
}
