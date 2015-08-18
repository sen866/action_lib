using action_game.sources.model.skill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.character
{
    [System.Serializable]
    public class BattleStatus
    {
        //  なんか微妙だけどUnity用。。。。
        public float attack;
        public float defense;
        public float hitpoint;
        public float stamina;
        public float staminaHealInterval;
        public float staminaHealValuePerInterval;
        public float knockBackAttack;
        public float knockBackRegist;

        public float Attack
        {
            set { attack = value; }
            get { return attack; }
        }
        public float Defense
        {
            set { defense = value; }
            get { return defense; }
        }
        public float HitPoint
        {
            set { hitpoint = value; }
            get { return hitpoint; }
        }
        public float Stamina
        {
            set { stamina = value; }
            get { return stamina; }
        }
        public float StaminaHealInterval
        {
            set { staminaHealInterval = value; }
            get { return staminaHealInterval; }
        }
        public float StaminaHealValuePerInterval
        {
            set { staminaHealValuePerInterval = value; }
            get { return staminaHealValuePerInterval; }
        }
        public float KnockBackAttack
        {
            set { knockBackAttack = value; }
            get { return knockBackAttack; }
        }
        public float KnockBackRegist
        {
            set { knockBackRegist = value; }
            get { return knockBackRegist; }
        }

        public BattleStatus()
        {
            Attack = 0.0f;
            Defense = 0.0f;
            HitPoint = 0.0f;
            Stamina = 0.0f;
            staminaHealInterval = 0.0f;
            staminaHealValuePerInterval = 0.0f;
            knockBackAttack = 0.0f;
            knockBackRegist = 0.0f;
        }

        public BattleStatus(float attack, float defense, float hitpoint, float stamina, float staminaHealInterval, float staminaHealValuePerInterval, float knockBackAttack, float knockBackRegist)
        {
            Attack = attack;
            Defense = defense;
            HitPoint = hitpoint;
            Stamina = stamina;
            StaminaHealInterval = staminaHealInterval;
            StaminaHealValuePerInterval = staminaHealValuePerInterval;
            KnockBackAttack = knockBackAttack;
            KnockBackRegist = knockBackRegist;
        }

        static public BattleStatus operator +(BattleStatus a, BattleStatus b)
        {
            return new BattleStatus(
                attack: a.Attack + b.Attack,
                defense: a.Defense + b.Defense,
                hitpoint: a.HitPoint + b.HitPoint,
                stamina: a.Stamina + b.Stamina,
                staminaHealInterval: a.StaminaHealInterval + b.StaminaHealValuePerInterval,
                staminaHealValuePerInterval: a.StaminaHealValuePerInterval + b.StaminaHealValuePerInterval,
                knockBackAttack:a.KnockBackAttack + b.KnockBackAttack,
                knockBackRegist:a.KnockBackRegist + b.KnockBackRegist
                );
        }

        public BattleStatus Clone()
        {
            return new BattleStatus(attack, defense, hitpoint, stamina, staminaHealInterval, staminaHealValuePerInterval, knockBackAttack, knockBackRegist);
        }
    }

    public delegate void BattleEventHandler(IBattlable battlable);

    public interface IBattlable
    {
        BattleStatus BattleStatus { get; set; }
        float CurrentHitPoint { get; set; }

        void Attack(IBattlable target);
        void Damaged(float damage);

        event BattleEventHandler OnDamage;
        event BattleEventHandler OnDead;
    }
}
