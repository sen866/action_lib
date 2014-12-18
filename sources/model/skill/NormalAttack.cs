using action_game.sources.model.character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.skill
{
    public class NormalAttack : ISkill
    {
        public NormalAttack(float executingTime)
        {
            this.executingTime = executingTime;
        }

        public float GetExecutingTime() { return executingTime; }

        public void Execute(ICharacterable executor)
        {
            if (OnExecute != null)
            {
                OnExecute(executor);
            }
        }

        private float executingTime { get; set; }


        public event Action<ICharacterable> OnExecute;
    }
}
