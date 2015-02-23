using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.trigger
{
    public class Once : TriggerReceivable
    {
        private TriggerListener listener;
        private Action action;

        private bool isActioned;

        public Once(String _trigger, Action _action)
        {
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

            action();

            isActioned = true;
        }

        public void Triggered(string trigger)
        {
            listener.Dispatch(trigger);
        }
    }
}
