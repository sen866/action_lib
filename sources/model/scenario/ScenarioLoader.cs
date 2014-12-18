using action_game.sources.model.scenario.parser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace action_game.sources.model.scenario
{
    public class ScenarioLoader
    {
        public static ScenarioData LoadFromText(string text)
        {
            ScenarioData result = new ScenarioData();

            var parsed = TokenParser.Parse(text);

            var builder = new builder.Root();
            result = builder.Build(parsed);
            return result;
        }
    }
}
