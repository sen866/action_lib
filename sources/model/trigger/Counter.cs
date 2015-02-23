using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.trigger
{
    public class Counter : TriggerReceivable
    {
        private TriggerListener listener;
        private Action action;

        private bool isActioned;
        private int activateCount;
        private int triggeredCount;

        public Counter(int _activateCount, String _trigger, Action _action)
        {
            activateCount = _activateCount;
            isActioned = false;


            listener = new TriggerListener();
            listener.Regist(_trigger, onTriggered);

            action = _action;
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
            }
        }

        public void Triggered(string trigger)
        {
            listener.Dispatch(trigger);
        }
    }
}
