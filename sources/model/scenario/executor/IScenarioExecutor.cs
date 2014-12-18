using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.scenario.executor
{
    public interface IScenarioExecutor
    {
        bool IsPlayed(IScenarioNode parent);

        void Play(ScenarioPlayer player, IScenarioNode parent);
    }
}
