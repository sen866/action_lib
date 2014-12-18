using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.scenario.builder
{
    class Element : IScenarioNodeBuildable
    {
        public IScenarioNode Build(IEnumerator<parser.token.ITokenable> tokens, IScenarioNode now, ScenarioData scenarioData)
        {
            //  とりあえず最初にくるのはタグのみ対応
            var tag = new Tag();
            return tag.Build(tokens, now, scenarioData);
        }

        public bool IsSyntax(IEnumerator<parser.token.ITokenable> tokens)
        {
            throw new NotImplementedException();
        }
    }
}
