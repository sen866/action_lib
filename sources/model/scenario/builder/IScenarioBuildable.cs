using action_game.sources.model.scenario;
using action_game.sources.model.scenario.parser.token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.scenario.builder
{
    public interface IScenarioNodeBuildable
    {
        bool IsSyntax(IEnumerator<ITokenable> tokens);
        IScenarioNode Build(IEnumerator<ITokenable> tokens, IScenarioNode now, ScenarioData scenarioData);
    }
}
