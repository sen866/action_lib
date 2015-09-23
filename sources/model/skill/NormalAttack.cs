using action_game.sources.model.character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.skill
{
    public class NormalAttack : ISkill
    {
        public NormalAttack(float executingTime, float chainTime, float recastingTime, int needToUseStamina, int usedStamina, float attack, float knockBack, Vector movePosition)
        {
            this.executingTime = executingTime;
            this.chainTime = chainTime;
            this.recastingTime = recastingTime;
            this.needToUseStamina = needToUseStamina;
            this.usedStamina = usedStamina;
            this.attack = attack;
            this.knockBack = knockBack;
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

            if (OnExecute != null)
            {
                OnExecute(executor, this);
            }

            float sinY = (float)Math.Sin(executor.CurrentRotation.y * Math.PI / 180.0f);
            float cosY = (float)Math.Cos(executor.CurrentRotation.y * Math.PI / 180.0f);

            Vector velocity = new Vector(movePosition.x * cosY + movePosition.z * sinY, movePosition.y, -movePosition.x * sinY + movePosition.z * cosY);

            velocity = velocity / executingTime;

            executor.SetVelocity(velocity.x, velocity.y, velocity.z);

            executor.CurrentState.OnEnd += onFinishExecute;

            return true;
        }

        private void onFinishExecute(ICharacterable executor)
        {
            executor.CurrentState.OnEnd -= onFinishExecute;

            executor.SetVelocity(0.0f, 0.0f, 0.0f);
        }


        private float executingTime { get; set; }
        private float chainTime { get; set; }
        private float recastingTime { get; set; }
        private int needToUseStamina { get; set; }
        private int usedStamina { get; set; }
        private float attack { get; set; }
        private float knockBack { get; set; }
        private Vector movePosition { get; set; }


        public event Action<ICharacterable, ISkill> OnExecute;


        public void Effect(ICharacterable executor, ICharacterable target, Vector hitPosition)
        {
            var damage = attack + executor.BattleCharacter.BattleStatus.Attack - target.BattleCharacter.BattleStatus.Defense;
            target.BattleCharacter.Damaged(damage);

            var knockBackDistance = knockBack + executor.BattleCharacter.BattleStatus.KnockBackAttack - target.BattleCharacter.BattleStatus.KnockBackRegist;

            if (knockBackDistance > 0.0f)
            {
                var direction = target.CurrentPosition - hitPosition;
                direction.y = 0.0f;

                direction = direction / direction.Magnitude();

                target.KnockBacked(direction * knockBackDistance);
            }
        }
    }
}
