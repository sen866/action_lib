using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.scenario.executor.text
{
    class Normal : Effectable
    {
        public Normal(String _text, float _delay)
        {
            nowLength = 0;
            text = _text;

            delay = _delay;
            nextPlayTime = 0.0f;

            isPlayed = false;
        }

        public void Play(ScenarioPlayer player, IScenarioNode parent)
        {
            if (isFirst)
            {
                isFirst = false;
                player.StartNewText(Say.ToTextType(parent.GetAttribute("class").Value), parent.GetAttribute("name").Value);
            }

            while (true)
            {
                if (nextPlayTime > player.Now) return;

                nowLength++;

                if (text.Length < nowLength)
                {
                    isPlayed = true;
                    return;
                }

                player.AddText(text.Substring(nowLength - 1, 1));

                nextPlayTime = player.Now + delay;
            }
        }


        private String text { get; set; }
        private int nowLength { get; set; }

        private float delay = 0.03f;
        private float nextPlayTime { get; set; }

        private bool isFirst = true;

        public bool IsPlayed(IScenarioNode parent)
        {
            return isPlayed;
        }

        private bool isPlayed { get; set; }
    }
}
