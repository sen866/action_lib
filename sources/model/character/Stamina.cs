using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.character
{
    public class Stamina
    {
        public float Max;
        private float healInterval;
        private float healValuePerInterval;

        private float now;
        private float nextHealTime;

        public event Action<Stamina> OnChange = delegate { };

        public Stamina(float _max, float _healInterval, float _healValuePerInterval)
        {
            now = 0.0f;
            Max = _max;
            healInterval = _healInterval;
            healValuePerInterval = _healValuePerInterval;

            if (healInterval == 0.0f)
            {
                healInterval = 1.0f;
            }

            nextHealTime = 0.0f;
        }

        public float Current
        {
            get
            {
                return now;
            }
            set
            {
                var before = now;

                now = value;

                now = Math.Min(now, Max);

                now = Math.Max(now, 0.0f);

                if (now != before)
                {
                    OnChange(this);
                }
            }
        }

        public bool Use(float used)
        {
            if (used > Current)
            {
                return false;
            }

            Current -= used;

            return true;
        }

        public void Update(float nowTime, float deltaTime)
        {
            if (Current >= Max)
            {
                //  これ以上回復しない
                nextHealTime = 0.0f;
                return;
            }

            if (nextHealTime <= 0.0f)
            {
                //  減ってから初回
                nextHealTime = nowTime + healInterval;
            }

            if (nextHealTime <= nowTime)
            {
                //  回復
                Current += (int)(((nowTime - nextHealTime) + healInterval) / healInterval) * healValuePerInterval;

                nextHealTime += healInterval;
            }
        }
    }
}
