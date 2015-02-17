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

        public IState Update(IThinkable parent, ICharacterable own, float now, float deltaTime)
        {
            own.Executioner.ExecuteNormal(now, own);

            return new state.Attacking(own);
        }
    }
}
