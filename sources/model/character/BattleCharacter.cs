using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.character
{
    public class BattleCharacter : IBattlable
    {
        public BattleCharacter(ICharacterable owner, BattleStatus _status)
        {
            this.owner = owner;
            BattleStatus = _status;
            //  現在ＨＰを最大にしておく
            CurrentHitPoint = status.HitPoint;
        }


        public BattleStatus BattleStatus
        {
            get
            {
                return status;
            }
            set
            {
                status = value;

                CurrentHitPoint = Math.Min(CurrentHitPoint, BattleStatus.HitPoint);

                OnHitpointChange(this);
            }
        }

        public float CurrentHitPoint
        {
            get
            {
                return currentHitpoint;
            }
            set
            {
                currentHitpoint = value;

                currentHitpoint = Math.Min(currentHitpoint, BattleStatus.HitPoint);

                OnHitpointChange(this);
            }
        }

        public void Attack(IBattlable target)
        {
            //  なんかこれあったほうが色々都合悪い気がするのでコメントアウト
            /*
            if (!owner.CurrentState.CanAttack())
            {
                return;
            }
            */
            var damage = BattleStatus.Attack - target.BattleStatus.Defense;
            target.Damaged(damage);
        }

        public void Healed(float heal)
        {
            CurrentHitPoint += heal;
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

        private BattleStatus status;

        private float currentHitpoint;

        public event BattleEventHandler OnDamage;

        public event BattleEventHandler OnHitpointChange = delegate { };

        public event BattleEventHandler OnDead;
    }
}
