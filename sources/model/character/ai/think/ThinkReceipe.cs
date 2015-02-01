using action_game.sources.model.character.ai.think.action;
using action_game.sources.model.character.ai.think.condition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.character.ai.think
{
    public class ThinkReceipe
    {
        public ThinkReceipe(ConditionGroup _conditions, Actable _action)
        {
            Conditions = _conditions;
            ThinkAction = _action;
        }

        public ConditionGroup Conditions { get; set; }
        public Actable ThinkAction { get; set; }
    };
}
