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

        public BattleStatus()
        {
            Attack = 0.0f;
            Defense = 0.0f;
            HitPoint = 0.0f;
        }

        public BattleStatus(float attack, float defense, float hitpoint)
        {
            Attack = attack;
            Defense = defense;
            HitPoint = hitpoint;
        }

        static public BattleStatus operator +(BattleStatus a, BattleStatus b)
        {
            return new BattleStatus(
                attack: a.Attack + b.Attack,
                defense: a.Defense + b.Defense,
                hitpoint: a.HitPoint + b.HitPoint
                );
        }

        public BattleStatus Clone()
        {
            return new BattleStatus(attack, defense, hitpoint);
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
