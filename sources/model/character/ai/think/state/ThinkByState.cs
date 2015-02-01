using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using action_game.sources.model.character.ai.think.state;
using action_game.sources.model.character.ai.think.condition;
using action_game.sources.model.character.ai.think.action;

namespace action_game.sources.model.character.ai.think.state
{
    public class ThinkByState : IThinkable
    {
        public ThinkByState( List<ThinkReceipe> receipes )
        {
            thinkReceipes = receipes;

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

        private List<ThinkReceipe> thinkReceipes;
    }
}
