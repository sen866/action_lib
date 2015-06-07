using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.scenario.executor.text
{
    interface Effectable
    {
        bool IsPlayed(IScenarioNode parent);

        void Play(ScenarioPlayer player, IScenarioNode parent);
    }
}
