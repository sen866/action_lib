using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using action_game.sources.model.scenario;
using action_game.sources.model.scenario.executor;

namespace action_game.sources.model.scenario
{
    public interface IScenarioNode
    {
        IScenarioNode GetChild(int index);
        IScenarioExecutor GetExecutor();
        IScenarioNode AddChild(IScenarioNode node);
        IEnumerable<IScenarioNode> GetChildren();

        IScenarioNode Parent { get; set; }
        IScenarioNode Next { get; set; }
        void AddAttribute(ScenarioAttribute attribute);
        ScenarioAttribute GetAttribute(String name);
    }
}
