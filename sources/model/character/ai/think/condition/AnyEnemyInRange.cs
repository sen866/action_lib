using action_game.sources.model.character.group;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.character.ai.think.condition
{
    public class AnyEnemyInRange : Checkable
    {
        public bool Check(ICharacterable own)
        {
            var enemies = Grouping.SearchEnemyGroup(own);

            var target = utility.AttackableSearcher.SearchTarget(own, enemies);

            return target != null;
        }
    }
}
