using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.scenario.executor.text
{
    class Fade : Effectable
    {
        public Fade(String _text, float _delay)
        {
            text = _text;

            delay = _delay;

            isPlayed = false;
        }

        public void Play(ScenarioPlayer player, IScenarioNode parent)
        {
            if (startPlayTime < 0.0f)
            {
                player.StartNewText(Say.ToTextType(parent.GetAttribute("class").Value), parent.GetAttribute("name").Value);

                startPlayTime = player.Now;

                player.AddText(text);
            }

            float deltaTime = player.Now - startPlayTime;

            if (delay <= 0.0f)
            {
                player.SetOpacity(1.0f);
            }
            else
            {
                player.SetOpacity((deltaTime) / delay);
            }

            if (deltaTime >= delay)
            {
                //  再生完了
                isPlayed = true;
                return;
            }
        }


        private String text { get; set; }
        private float delay { get; set; }
        private float startPlayTime = -1.0f;

        public bool IsPlayed(IScenarioNode parent)
        {
            return isPlayed;
        }

        private bool isPlayed { get; set; }
    }
}
