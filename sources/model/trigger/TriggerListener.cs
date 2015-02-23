using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.trigger
{
    class TriggerListener
    {
        private Dictionary<String, Action> handlers;


        public TriggerListener()
        {
            handlers = new Dictionary<string,Action>();
        }

        public void Regist(String trigger, Action handler)
        {
            if (handlers.ContainsKey(trigger))
            {
                handlers[trigger] += handler;
            }
            else
            {
                handlers.Add(trigger, handler);
            }
        }

        public void Remove(String trigger, Action handler)
        {
            handlers[trigger] -= handler;
        }

        public void Dispatch(String trigger)
        {
            Action result;
            if (handlers.TryGetValue(trigger, out result))
            {
                result();
            }
        }
    }
}
