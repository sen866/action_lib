using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.scenario.executor
{
    class Text : IScenarioExecutor
    {
        public Text(String _text)
        {
            nowLength = 0;
            this._text = _text;

            isPlayed = false;
        }

        public bool IsPlayed(IScenarioNode parent)
        {
            return isPlayed;
        }

        private String _text { get; set; }
        private int nowLength { get; set; }

        private bool isPlayed { get; set; }


        public void Play(ScenarioPlayer player, IScenarioNode parent)
        {
            nowLength++;

            if (_text.Length < nowLength)
            {
                isPlayed = true;
                return;
            }

            player.AddText(_text.Substring(nowLength - 1, 1));
        }
    }
}
