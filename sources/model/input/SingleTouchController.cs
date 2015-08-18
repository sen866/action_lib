using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.input
{
    public delegate void SingleTouchEventHandler(TouchEvent began, TouchEvent ended);

    //  最後のタッチを開始したもののみをイベント監視してそれ以外のタッチはキャンセル扱いにしてしまう
    public static class SingleTouchController
    {
        static SingleTouchController()
        {
            InputEventListener.OnTouchBegan += onTouchBegan;
            InputEventListener.OnTouchEnded += onTouchEnded;
            InputEventListener.OnTouchCanceled += onTouchCanceled;
            InputEventListener.OnTouchMoved += onTouchMoved;
            InputEventListener.OnTouchStationary += onTouchStationary;
        }

        static private void onTouchBegan(TouchEvent touchEvent)
        {
            lastTouchEvent = touchEvent;
        }

        static private float calculateTouchDistance(TouchPosition began, TouchPosition ended)
        {
            var distance = Math.Pow(ended.x - began.x, 2) + Math.Pow(ended.y - began.y, 2);
            return (float)distance;
        }

        static private void onTouchEnded(TouchEvent touchEvent)
        {
            isSwiping = false;

            if (lastTouchEvent.id != touchEvent.id) return;

            //  ここで普通のタッチかフリックorスワイプかを分岐する
            if (calculateTouchDistance(lastTouchEvent.position, touchEvent.position) < 20.0f)
            {
                //  このときはタッチ
                if (OnTouch != null)
                    OnTouch(lastTouchEvent, touchEvent);

                return;
            }

            //  ここでフリックとスワイプどちらかのイベントを発行する
            if (isFlick(lastTouchEvent.time, touchEvent.time))
            {
                //  フリックの判定時間内
                if (OnFlick != null)
                    OnFlick(lastTouchEvent, touchEvent);
            }
            else
            {
                if (OnSwipeEnded != null)
                    OnSwipeEnded(lastTouchEvent, touchEvent);
            }
        }

        static private void onTouchCanceled(TouchEvent touchEvent)
        {
            if (lastTouchEvent.id != touchEvent.id) return;

            //  スワイプ中だったらスワイプ終了をコールバック
            if (isSwiping)
            {
                if (OnSwipeEnded != null)
                    OnSwipeEnded(lastTouchEvent, touchEvent);
            }

            isSwiping = false;
        }

        static private void onTouchMoved(TouchEvent touchEvent)
        {
            if (lastTouchEvent.id != touchEvent.id) return;

            //  まだフリック入力の判定時間である
            if (isFlick(lastTouchEvent.time, touchEvent.time)) return;

            if (OnSwipe != null)
                OnSwipe(lastTouchEvent, touchEvent);

            isSwiping = true;
        }

        static private void onTouchStationary(TouchEvent touchEvent)
        {
            if (lastTouchEvent.id != touchEvent.id) return;

            //  まだフリック入力の判定時間である
            if (isFlick(lastTouchEvent.time, touchEvent.time)) return;

            if (OnSwipe != null)
                OnSwipe(lastTouchEvent, touchEvent);

            isSwiping = true;
        }

        static private bool isFlick(float start, float end)
        {
            return (end - start) * 1000 <= FLICK_MAX_MILLISECONDS_TIME;
        }

        static public event SingleTouchEventHandler OnTouch;
        static public event SingleTouchEventHandler OnFlick;
        static public event SingleTouchEventHandler OnSwipe;
        static public event SingleTouchEventHandler OnSwipeEnded;


        private const int FLICK_MAX_MILLISECONDS_TIME = 400;

        //  一番最後にタッチが開始されたものを覚えておく
        static private TouchEvent lastTouchEvent { get; set; }

        static private bool isSwiping = false;
    }
}
