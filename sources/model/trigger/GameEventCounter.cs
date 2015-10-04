using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.trigger
{
    public class GameEventCounter
    {
        private GameEventTypes trigger;
        private Action action;

        private bool isActioned;
        private int activateCount;
        private int triggeredCount;
        private bool isTriggeredReset;

        public GameEventCounter(int _activateCount, GameEventTypes _trigger, Action _action, bool _isTriggeredReset)
        {
            activateCount = _activateCount;
            trigger = _trigger;
            isActioned = false;

            action = _action;
            isTriggeredReset = _isTriggeredReset;

            EventListener.Regist(trigger, onTrigger);
        }

        private void onTrigger()
        {
            if (isActioned)
            {
                return;
            }

            triggeredCount++;

            if (triggeredCount >= activateCount)
            {
                action();
                isActioned = true;

                if (isTriggeredReset)
                {
                    isActioned = false;
                    triggeredCount = 0;
                }
            }
        }

        public void Dispose()
        {
            action = null;
        }
    }
}
