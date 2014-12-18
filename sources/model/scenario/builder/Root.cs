using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.scenario.builder
{
    public class Root
    {
        public ScenarioData Build(IEnumerable<parser.token.ITokenable> tokens)
        {
            var result = new ScenarioData();
            result.ScenarioRoot = new ScenarioElement();
            var now = result.ScenarioRoot;

            var enumerator = tokens.GetEnumerator();
            enumerator.MoveNext();
            for (; enumerator.Current.Next != null; )
            {
                var element = new Element();
                now.Next = element.Build(enumerator, now, result);
                now = now.Next;
            }

            return result;
        }
    }
}
