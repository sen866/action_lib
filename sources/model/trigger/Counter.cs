using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.trigger
{
    public class Counter : TriggerReceivable
    {
        private TriggerListener listener;
        private String trigger;
        private Action action;

        private bool isActioned;
        private int activateCount;
        private int triggeredCount;
        private bool isTriggeredReset;

        public Counter(int _activateCount, String _trigger, Action _action, bool _isTriggeredReset)
        {
            activateCount = _activateCount;
            trigger = _trigger;
            isActioned = false;


            listener = new TriggerListener();
            listener.Regist(_trigger, onTriggered);

            action = _action;
            isTriggeredReset = _isTriggeredReset;
        }

        ~Counter()
        {
            throw new Exception();
        }

        private void onTriggered()
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

        public void Triggered(string trigger)
        {
            listener.Dispatch(trigger);
        }

        public void Dispose()
        {
            listener.Remove(trigger, onTriggered);

            action = null;
        }
    }
}
