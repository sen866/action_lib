using action_game.sources.model.character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.skill
{
    public class NormalAttack : ISkill
    {
        public NormalAttack(float executingTime, float chainTime, float recastingTime)
        {
            this.executingTime = executingTime;
            this.chainTime = chainTime;
            this.recastingTime = recastingTime;
        }

        public float GetExecutingTime() { return executingTime; }

        public float GetChainTime() { return chainTime; }

        public float GetRecastingTime() { return recastingTime; }

        public void Execute(ICharacterable executor)
        {
            if (OnExecute != null)
            {
                OnExecute(executor);
            }
        }

        private float executingTime { get; set; }
        private float chainTime { get; set; }
        private float recastingTime { get; set; }


        public event Action<ICharacterable> OnExecute;
    }
}
