using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model
{
    public static class EventListener
    {
        private static Dictionary<GameEventTypes, Action> gameEventHandlers;
        private static Dictionary<ActionEventTypes, Action> actionEventHandlers;


        static EventListener()
        {
            gameEventHandlers = new Dictionary<GameEventTypes, Action>();
            actionEventHandlers = new Dictionary<ActionEventTypes, Action>();
        }

        public static void Regist(GameEventTypes type, Action handler)
        {
            if (gameEventHandlers.ContainsKey(type))
            {
                gameEventHandlers[type] += handler;
            }
            else
            {
                gameEventHandlers.Add(type, handler);
            }
        }

        public static void Remove(GameEventTypes type, Action handler)
        {
            gameEventHandlers[type] -= handler;
        }

        public static void Dispatch(GameEventTypes type)
        {
            Action result;
            if (gameEventHandlers.TryGetValue(type, out result))
            {
                result();
            }
        }


        public static void Regist(ActionEventTypes type, Action handler)
        {
            if (actionEventHandlers.ContainsKey(type))
            {
                actionEventHandlers[type] += handler;
            }
            else
            {
                actionEventHandlers.Add(type, handler);
            }
        }

        public static void Remove(ActionEventTypes type, Action handler)
        {
            actionEventHandlers[type] -= handler;
        }

        public static void Dispatch(ActionEventTypes type)
        {
            Action result;
            if (actionEventHandlers.TryGetValue(type, out result))
            {
                result();
            }
        }
    }
}
