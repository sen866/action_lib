using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.scenario.builder.command
{
    class Center : ICommandable
    {
        public bool HasEndTag()
        {
            return false;
        }

        public bool IsSyntax(IEnumerator<parser.token.ITokenable> tokens)
        {
            var tmp = tokens.Current;
            if ((tmp.GetType() != parser.token.TokenType.LeftArrow) || tmp.Next == null)
            {
                return false;
            }

            tmp = tmp.Next;

            if ((tmp.GetType() != parser.token.TokenType.Word))
            {
                return false;
            }

            if ((tmp.GetToken() != Command.Center || tmp.Next == null))
            {
                return false;
            }

            tmp = tmp.Next;

            //  attribute解析
            while (tmp.GetType() != parser.token.TokenType.RightArrow)
            {
                tmp = tmp.Next;
            }

            if ((tmp.GetType() != parser.token.TokenType.RightArrow) || tmp.Next == null)
            {
                return false;
            }

            return true;
        }

        public IScenarioNode Build(IEnumerator<parser.token.ITokenable> tokens, IScenarioNode now, ScenarioData scenarioData)
        {
            var result = new ScenarioElement();

            //  attribute解析
            while (tokens.Current.GetType() != parser.token.TokenType.RightArrow)
            {
                var attribute = new Attribute();
                result.AddAttribute(attribute.Build(tokens, result, scenarioData));
            }

            result.SetExecutor(new executor.Center(result));

            return result;
        }
    }
}
