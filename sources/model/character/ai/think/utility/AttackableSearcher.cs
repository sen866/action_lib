using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.character.ai.think.utility
{
    public static class AttackableSearcher
    {
        public static ActionCharacter SearchTarget(ICharacterable own, List<ActionCharacter> targets)
        {
            return targets
            .Where(_ => AttackableDistance.checkDistance(own, _))
            .FirstOrDefault();
        }
    }
}
