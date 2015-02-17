using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.character.ai.think.condition
{
    public class HitpointRateMoreThanEqual : Checkable
    {
        public HitpointRateMoreThanEqual(float _rate)
        {
            rate = _rate;
        }

        public bool Check(ICharacterable own)
        {
            // HPの残りの割合を出す
            var nowRate = own.BattleCharacter.CurrentHitPoint / own.BattleCharacter.BattleStatus.HitPoint * 100.0f;

            return nowRate >= rate;
        }

        private float rate { get; set; }
    }
}
