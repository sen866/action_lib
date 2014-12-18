using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.scenario.executor
{
    class WaitNext : IScenarioExecutor
    {
        public WaitNext()
        {
            isPlayed = false;
        }

        public bool IsPlayed(IScenarioNode parent)
        {
            return isPlayed;
        }

        private bool isPlayed { get; set; }


        public void Play(ScenarioPlayer player, IScenarioNode parent)
        {
            throw new NotImplementedException();
        }
    }
}
