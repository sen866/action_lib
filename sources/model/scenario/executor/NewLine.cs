using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.scenario.executor
{
    class NewLine : IScenarioExecutor
    {
        public NewLine()
        {
            isPlayed = false;
        }

        public bool IsPlayed(IScenarioNode parent)
        {
            return isPlayed;
        }


        public void Play(ScenarioPlayer player, IScenarioNode parent)
        {
            player.AddText(System.Environment.NewLine);

            isPlayed = true;
        }

        private bool isPlayed { get; set; }
    }
}
