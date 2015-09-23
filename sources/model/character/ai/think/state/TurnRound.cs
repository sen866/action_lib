using action_game.sources.model.character.group;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.character.ai.think.state
{
    class TurnRound : IState
    {
        public TurnRound(ICharacterable own, float _waitTime)
        {
            waitTime = _waitTime;

            elapsedTime = 0.0f;

            //  一番近い敵に向きを変える
            var enemies = Grouping.SearchEnemyGroup(own);

            if (enemies.Count != 0)
            {
                var target = enemies.First();

                var direction = target.CurrentPosition - own.CurrentPosition;
                own.SetRotation(0.0f, (float)(180.0f / Math.PI * Math.Atan2(direction.x, direction.z)), 0.0f);
            }
        }

        public IState Update(IThinkable parent, ICharacterable own, float now, float deltaTime)
        {
            elapsedTime += deltaTime;

            if (elapsedTime < waitTime)
            {
                return this;
            }

            return new state.Attack();
        }

        private float waitTime { get; set; }

        private float elapsedTime { get; set; }
    }
}
