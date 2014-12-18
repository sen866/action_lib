using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.character
{
    public class BattleCharacter : IBattlable
    {
        public BattleCharacter(ICharacterable owner, BattleStatus status)
        {
            this.owner = owner;
            BattleStatus = status;
            //  現在ＨＰを最大にしておく
            CurrentHitPoint = status.HitPoint;
        }

        public BattleStatus BattleStatus { get; set; }

        public float CurrentHitPoint { get; set; }

        public void Attack(IBattlable target)
        {
            if (!owner.CurrentState.CanAttack())
            {
                return;
            }
            var damage = BattleStatus.Attack - target.BattleStatus.Defense;
            target.Damaged(damage);
        }


        public void Damaged(float damage)
        {
            CurrentHitPoint -= damage;

            if (OnDamage != null)
                OnDamage(this);

            //  HPがもうない
            if (CurrentHitPoint <= 0.0f)
            {
                if (OnDead != null)
                    OnDead(this);
            }
        }

        private ICharacterable owner;

        public event BattleEventHandler OnDamage;

        public event BattleEventHandler OnDead;
    }
}
