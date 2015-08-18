using action_game.sources.model.character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.skill
{
    public class NormalHeal : ISkill
    {
        public NormalHeal(float executingTime, float chainTime, float recastingTime, int needToUseStamina, int usedStamina, float heal, float healRate)
        {
            this.executingTime = executingTime;
            this.chainTime = chainTime;
            this.recastingTime = recastingTime;
            this.needToUseStamina = needToUseStamina;
            this.usedStamina = usedStamina;
            this.heal = heal;
            this.healRate = healRate;
        }

        public float GetExecutingTime() { return executingTime; }

        public float GetChainTime() { return chainTime; }

        public float GetRecastingTime() { return recastingTime; }

        public int GetNeedToUseStamina()
        {
            return needToUseStamina;
        }

        public int GetUsedStamina()
        {
            return usedStamina;
        }

        public bool Execute(ICharacterable executor)
        {
            if (executor.BattleCharacter.Stamina.Current < GetNeedToUseStamina())
            {
                return false;
            }

            if (!executor.BattleCharacter.Stamina.Use(GetUsedStamina()))
            {
                return false;
            }

            if (OnExecute != null)
            {
                OnExecute(executor, this);
            }

            return true;
        }

        private float executingTime { get; set; }
        private float chainTime { get; set; }
        private float recastingTime { get; set; }
        private int needToUseStamina { get; set; }
        private int usedStamina { get; set; }
        private float heal { get; set; }
        private float healRate { get; set; }


        public event Action<ICharacterable, ISkill> OnExecute;


        public void Effect(ICharacterable executor, ICharacterable target, Vector hitPosition)
        {
            var healed = heal + executor.BattleCharacter.BattleStatus.HitPoint * healRate;
            target.BattleCharacter.Healed(healed);
        }
    }
}
