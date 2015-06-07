using action_game.sources.model.input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.scenario.executor
{
    class Say : IScenarioExecutor
    {
        private enum State
        {
            PlayEndWait,
            WaitNext,
            Next,
        }

        bool isWaitClick = true;

        public Say()
        {
            nowIndex = 0;
            now = null;
            nextPlayTime = 0.0f;
            nowState = State.PlayEndWait;
        }

        private bool isWaitNext()
        {
            return nowState != State.Next;
        }

        public bool IsPlayed(IScenarioNode parent)
        {
            if (isWaitNext())
            {
                //  次へ進むのを待っている
                return false;
            }

            return parent.GetChildren().All(
                child => child.GetExecutor() == null || child.GetExecutor().IsPlayed(child)
                );
        }

        private IScenarioNode parent { get; set; }


        public void Play(ScenarioPlayer player, IScenarioNode parent)
        {
            //  再生完了している(親から呼ばれないはずなので必要ないきもする
            if (IsPlayed(parent)) return;

            if (now == null)
            {
                playFirstBefore(player, parent);
            }

            if (now.GetExecutor() == null || now.GetExecutor().IsPlayed(now))
            {
                //  再生完了
                nowIndex++;
                try
                {
                    now = parent.GetChild(nowIndex);
                }
                catch (System.ArgumentOutOfRangeException)
                {
                    //  多分終わり
                    if (isWaitClick)
                    {
                        nowState = State.WaitNext;
                    }
                    else
                    {
                        nowState = State.Next;
                    }
                    return;
                }
            }

            if (now.GetExecutor() == null)
            {
                return;
            }

            now.GetExecutor().Play(player, parent);
        }

        private void playFirstBefore(ScenarioPlayer player, IScenarioNode parent)
        {
            player.ClearText();

            if (parent.GetAttribute("isWaitClick").Value == "false")
            {
                isWaitClick = false;
            }

            //  TODO文字列長計算したりとか
            now = parent.GetChildren().First();

            SingleTouchController.OnTouch += onTouch;
        }

        public static TextType ToTextType(String type)
        {
            switch (type)
            {
                case "center default": return TextType.CenterSay;
                case "left default": return TextType.LeftSay;
                case "right default": return TextType.RightSay;
                case "center shout": return TextType.CenterShout;
                case "left shout": return TextType.LeftShout;
                case "right shout": return TextType.RightShout;
            }
            return TextType.Normal;
        }

        private void onTouch(TouchEvent began, TouchEvent ended)
        {
            //  次へ進むのを待っていなければ受け付けない
            if (nowState != State.WaitNext) return;

            nowState = State.Next;

            SingleTouchController.OnTouch -= onTouch;
        }

        private int nowIndex { get; set; }
        private IScenarioNode now { get; set; }
        private float nextPlayTime { get; set; }
        private State nowState { get; set; }
    }
}
