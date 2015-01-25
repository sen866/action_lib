using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.character.ai.think.condition
{
    class ConditionGroup : Checkable
    {
        public ConditionGroup(List<Checkable> _conditions)
        {
            conditions = _conditions;
        }

        public bool Check(ICharacterable own)
        {
            return conditions.All(_ => _.Check(own));
        }

        private List<Checkable> conditions { get; set; }
    }
}
