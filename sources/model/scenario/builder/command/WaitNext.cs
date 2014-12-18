using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.scenario.builder.command
{
    class WaitNext : ICommandable
    {
        public bool HasEndTag()
        {
            return false;
        }

        public IScenarioNode Build(IEnumerator<parser.token.ITokenable> tokens, IScenarioNode now, ScenarioData scenarioData)
        {
            if ((tokens.Current.GetType() != parser.token.TokenType.LeftArrow) || !tokens.MoveNext())
            {
                throw new SyntaxErrorException();
            }

            if ((tokens.Current.GetType() != parser.token.TokenType.Word))
            {
                throw new SyntaxErrorException();
            }

            if ((tokens.Current.GetToken() != Command.WaitNext || !tokens.MoveNext()))
            {
                throw new SyntaxErrorException();
            }

            if ((tokens.Current.GetType() != parser.token.TokenType.Slash) || !tokens.MoveNext())
            {
                throw new SyntaxErrorException();
            }

            if ((tokens.Current.GetType() != parser.token.TokenType.RightArrow) || !tokens.MoveNext())
            {
                throw new SyntaxErrorException();
            }

            return new ScenarioElement(
                new executor.WaitNext()
                );
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

            if ((tmp.GetToken() != Command.WaitNext || tmp.Next == null))
            {
                return false;
            }

            tmp = tmp.Next;

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
    }
}
