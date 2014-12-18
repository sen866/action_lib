using action_game.sources.model.utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.character.ai.think.state
{
    class RandomWalk : IState
    {
        public IState Update(ICharacterable own, float now, float deltaTime)
        {
            if (!own.CanMove())
            {
                return this;
            }

            Vector direction = new Vector();

            if (GlobalRandom.Generator.Next() % 2 == 0)
            {
                direction.x = (float)(GlobalRandom.Generator.NextDouble() - 0.5);
            }
            if (GlobalRandom.Generator.Next() % 2 == 0)
            {
                direction.z = (float)(GlobalRandom.Generator.NextDouble() - 0.5);
            }

            if (direction.Magnitude() != 0.0f)
            {
                direction = direction / direction.Magnitude();
            }
            direction = direction * own.RunMaxSpeed;

            own.SetVelocity(direction.x, direction.y, direction.z);

            return new state.Walking( 0.5f );
        }
    }
}
