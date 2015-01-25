using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using action_game.sources.model.character.ai.think.state;
using action_game.sources.model.character.ai.think.condition;
using action_game.sources.model.character.ai.think.action;

namespace action_game.sources.model.character.ai.think.state
{
    class ThinkByState : IThinkable
    {
        public ThinkByState()
        {
            thinkReceipes = new List<ThinkReceipe>()
            {
                new ThinkReceipe(
                    new ConditionGroup(
                        new List<Checkable>()
                        {
                            new think.condition.AnyEnemyInRange()
                        }
                    ),
                    new think.action.Attack()
                ),
                new ThinkReceipe(
                    new ConditionGroup(
                        new List<Checkable>()
                        {
                            new think.condition.Unconditional()
                        }
                     ),
                     new think.action.RandomWalk()
                )
            }
            ;
            state = new Wait();
        }

        public action.Actable ThinkNext(ICharacterable own, float now, float deltaTime)
        {
            var receipe = thinkReceipes.Find(_ => _.Conditions.Check(own));

            return receipe == null ? null : receipe.ThinkAction;
        }

        public void Update(ICharacterable own, float now, float deltaTime)
        {
            state = state.Update(this, own, now, deltaTime);
        }

        private IState state { get; set; }

        class ThinkReceipe
        {
            public ThinkReceipe(ConditionGroup _conditions, Actable _action)
            {
                Conditions = _conditions;
                ThinkAction = _action;
            }

            public ConditionGroup Conditions { get; set; }
            public Actable ThinkAction { get; set; }
        };

        private List<ThinkReceipe> thinkReceipes;
    }
}
