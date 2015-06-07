using action_game.sources.model.scenario;
using action_game.sources.model.scenario.builder;
using action_game.sources.model.scenario.parser.token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.scenario.builder
{
    class Text : IScenarioNodeBuildable
    {
        public IScenarioNode Build(IEnumerator<ITokenable> tokens, IScenarioNode now, ScenarioData scenarioData)
        {
            String text = tokens.Current.GetToken();
            tokens.MoveNext();

            while (IsSyntax(tokens))
            {
                text += System.Environment.NewLine;
                text += tokens.Current.GetToken();
                tokens.MoveNext();
            }
            return new ScenarioElement(
                new executor.Text(text, now.GetAttribute("effect").Value, float.Parse(now.GetAttribute("delay").Value))
                );
        }

        public bool IsSyntax(IEnumerator<ITokenable> tokens)
        {
            return tokens.Current.GetType() == TokenType.Word;
        }
    }
}
