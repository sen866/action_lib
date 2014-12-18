using action_game.sources.model.character.group;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.character.ai.think.state
{
    class Attack : IState
    {
        public Attack()
        {
        }

        public IState Update(ICharacterable own, float now, float deltaTime)
        {
            var enemies = Grouping.SearchEnemyGroup(own);

            var target = utility.AttackableSearcher.SearchTarget(own, enemies);

            if (target == null)
            {
                return new state.Wait();
            }

            own.Executioner.execute(now, own, own.SkillHolder.Current);

            return new state.Attacking(own);
        }
    }
}
