using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.scenario.builder.command
{
    class Image : ICommandable
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

            if ((tmp.GetToken() != Command.Image || tmp.Next == null))
            {
                return false;
            }

            tmp = tmp.Next;

            //  attribute解析
            while (tmp.GetType() != parser.token.TokenType.Slash)
            {
                tmp = tmp.Next;
            }

            if ((tmp.GetType() != parser.token.TokenType.Slash) || tmp.Next == null)
            {
                return false;
            }

            tmp = tmp.Next;

            if ((tmp.GetType() != parser.token.TokenType.RightArrow))
            {
                return false;
            }
            return true;
        }

        public IScenarioNode Build(IEnumerator<parser.token.ITokenable> tokens, IScenarioNode now, ScenarioData scenarioData)
        {
            var result = new ScenarioElement();

            //  attribute解析
            while (tokens.Current.GetType() != parser.token.TokenType.Slash)
            {
                var attribute = new Attribute();
                result.AddAttribute(attribute.Build(tokens, result, scenarioData));
            }

            return result;
        }
    }
}
