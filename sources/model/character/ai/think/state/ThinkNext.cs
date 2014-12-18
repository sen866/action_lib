using action_game.sources.model.character.group;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.character.ai.think.state
{
    //  次何をするか考える状態
    class ThinkNext : IState
    {
        public IState Update(ICharacterable own, float now, float deltaTime)
        {

            if (checkNextAttack(own))
            {
                return new state.Attack();
            }

            return new state.RandomWalk();
        }

        private bool checkNextAttack(ICharacterable own)
        {
            var enemies = Grouping.SearchEnemyGroup(own);

            var target = utility.AttackableSearcher.SearchTarget(own, enemies);

            return target != null;
        }
    }
}
