using action_game.sources.model.character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.skill
{
    public class Invincible : ISkill
    {
        public Invincible(float executingTime, float chainTime, float recastingTime, int needToUseStamina, int usedStamina, float invincibleTime, Vector movePosition)
        {
            this.executingTime = executingTime;
            this.chainTime = chainTime;
            this.recastingTime = recastingTime;
            this.needToUseStamina = needToUseStamina;
            this.usedStamina = usedStamina;
            this.invincibleTime = invincibleTime;
            this.movePosition = movePosition;
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

            executor.IsInvincible = true;

            if (OnExecute != null)
            {
                OnExecute(executor, this);
            }

            new utility.WaitTimer(invincibleTime, delegate { onFinishExecute(executor); });

            float sinY = (float)Math.Sin(executor.CurrentRotation.y * Math.PI / 180.0f);
            float cosY = (float)Math.Cos(executor.CurrentRotation.y * Math.PI / 180.0f);

            Vector next = executor.CurrentPosition + new Vector(movePosition.x * cosY + movePosition.z * sinY, movePosition.y, -movePosition.x * sinY + movePosition.z * cosY);

            executor.SetPosition(next.x, next.y, next.z);

            return true;
        }

        private void onFinishExecute(ICharacterable executor)
        {
            executor.IsInvincible = false;
        }

        private float executingTime { get; set; }
        private float chainTime { get; set; }
        private float recastingTime { get; set; }
        private int needToUseStamina { get; set; }
        private int usedStamina { get; set; }
        private float invincibleTime { get; set; }
        private Vector movePosition { get; set; }


        public event Action<ICharacterable, ISkill> OnExecute;


        public void Effect(ICharacterable executor, ICharacterable target, Vector hitPosition)
        {
            throw new NotImplementedException();
        }
    }
}
