using action_game.OGamesProject.sources.model.character;
using action_game.sources.model.character.item;
using action_game.sources.model.character.state;
using action_game.sources.model.skill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.character
{
    public class ActionCharacter : ICharacterable
    {
        public ActionCharacter(BattleStatus status, GroupId groupId, GroupTag tag, Vector pos, float gravity, float runSpeed, SkillHolder skillHolder, EquipItemHolder equipItemHolder)
        {
            CurrentState = new Idle();
            Executioner = new Executioner();
            CurrentPosition = pos;
            Gravity = gravity;
            SkillHolder = skillHolder;
            PickupItemHolder = new PickupItemHolder();
            PickupItemHolder.OnPickedItem += UpdateBattleStatus;
            PickupItemHolder.OnPickedItem += UpdateRunMaxSpeed;
            EquipItemHolder = equipItemHolder;
            BaseStatus = status;
            BattleCharacter = new BattleCharacter(this, BattleStatusCalculator.calculate(status, this));

            BasicRunMaxSpeed = runSpeed;

            RunMaxSpeed = SpeedCalculator.Calculate(BasicRunMaxSpeed, this);

            GroupId = groupId;

            GroupTag = tag;

            Id = Guid.NewGuid();
        }

        public Vector CurrentPosition { get; private set; }

        public Vector SetPosition(float x, float y, float z)
        {
            CurrentPosition = new Vector(x, y, z);

            if (OnMove != null)
                OnMove(this);

            return CurrentPosition;
        }


        public Vector SetVelocity(float x, float y, float z)
        {
            CurrentVelocity = new Vector(x, y, z);

            if (OnChangeVelocity != null)
                OnChangeVelocity(this);

            return CurrentVelocity;
        }

        public Vector CurrentVelocity { get; private set; }

        public Vector SetRotation(float x, float y, float z)
        {
            CurrentRotation = new Vector(x, y, z);
            return CurrentRotation;
        }

        public Vector CurrentRotation { get; private set; }

        public event MovableEvent OnMove;
        public event MovableEvent OnChangeVelocity;


        public Executioner Executioner { get; set; }


        public event StateChangableEvent OnChangeState;
        public event StateChangableEvent OnStateEnd;

        public IState CurrentState { get; private set; }


        public bool ChangeState(IState state)
        {
            if (CurrentState == state)
            {
                //  すでにその状態である
                return false;
            }

            if (!CurrentState.IsToChangable(state))
            {
                return false;
            }

            if (!state.IsFromChangable(CurrentState))
            {
                return false;
            }

            if (OnStateEnd != null)
            {
                OnStateEnd(this);
            }

            CurrentState.Exit();

            CurrentState = state;
            if (OnChangeState != null)
                OnChangeState(this);

            CurrentState.Enter();

            return true;
        }

        public bool CanMove()
        {
            return CurrentState.CanMove();
        }


        public SkillHolder SkillHolder { get; set; }


        public void updateNextState(float now)
        {
            if (!CurrentState.IsNextStateTime(now))
                return;

            ChangeState(CurrentState.GetNextState());
        }


        public float Gravity { get; private set; }

        public void updateVelocity(float deltaTime)
        {
            SetVelocity(
                CurrentVelocity.x,
                CurrentVelocity.y - Gravity * deltaTime,
                CurrentVelocity.z
                );
        }


        public void update(float now, float deltaTime)
        {
            updateVelocity(deltaTime);
            updateNextState(now);
        }

        public void UpdateBattleStatus()
        {
            BattleCharacter.BattleStatus = BattleStatusCalculator.calculate(BaseStatus, this);
        }

        public void UpdateRunMaxSpeed()
        {
            RunMaxSpeed = SpeedCalculator.Calculate(BasicRunMaxSpeed, this);
        }

        public BattleStatus BaseStatus { get; set; }

        public PickupItemHolder PickupItemHolder { get; set; }

        public EquipItemHolder EquipItemHolder { get; set; }

        public BattleCharacter BattleCharacter { get; set; }

        public float RunMaxSpeed { get; set; }

        public float BasicRunMaxSpeed { get; set; }

        public GroupId GroupId { get; set; }

        public GroupTag GroupTag { get; set; }

        public Guid Id { get; set; }
    }
}
