using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.input
{
    public struct TouchPosition
    {
        public TouchPosition(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public float x;
        public float y;
    }

    public struct TouchEvent
    {
        public TouchEvent(float time, int id, TouchPosition position, int tapCount)
        {
            this.time = time;
            this.id = id;
            this.position = position;
            this.tapCount = tapCount;
        }

        public float time;
        public int id;
        public TouchPosition position;
        public int tapCount;
    }

    public delegate void TouchEventHandler(TouchEvent touchEvent);

    public static class InputEventListener
    {
        public static void TouchBegan(TouchEvent touchEvent)
        {
            if (OnTouchBegan != null)
                OnTouchBegan(touchEvent);
        }

        public static void TouchEnded(TouchEvent touchEvent)
        {
            if (OnTouchEnded != null)
                OnTouchEnded(touchEvent);
        }

        public static void TouchCanceled(TouchEvent touchEvent)
        {
            if (OnTouchCanceled != null)
                OnTouchCanceled(touchEvent);
        }

        public static void TouchMoved(TouchEvent touchEvent)
        {
            if (OnTouchMoved != null)
                OnTouchMoved(touchEvent);
        }

        public static void TouchStationary(TouchEvent touchEvent)
        {
            if (OnTouchStationary != null)
                OnTouchStationary(touchEvent);
        }

        public static event TouchEventHandler OnTouchBegan;
        public static event TouchEventHandler OnTouchEnded;
        public static event TouchEventHandler OnTouchCanceled;
        public static event TouchEventHandler OnTouchMoved;
        public static event TouchEventHandler OnTouchStationary;
    }
}
