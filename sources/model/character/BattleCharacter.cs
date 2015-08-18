using action_game.sources.model.skill;
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

            Stamina = new Stamina(BattleStatus.Stamina, BattleStatus.StaminaHealInterval, BattleStatus.StaminaHealValuePerInterval);
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
            throw new Exception("please don't used this method.");
        }

        public void Attack(ISkill skill, BattleCharacter target, Vector hitPosition)
        {
            skill.Effect(this.owner, target.owner, hitPosition);
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

        public void Update(float now, float deltaTime)
        {
            Stamina.Update(now, deltaTime);
        }

        private ICharacterable owner;

        private BattleStatus status;

        private float currentHitpoint;

        public Stamina Stamina { get; private set; }

        public event BattleEventHandler OnDamage;

        public event BattleEventHandler OnHitpointChange = delegate { };

        public event BattleEventHandler OnDead;
    }
}
