using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.scenario.builder
{
    class Attribute
    {
        public scenario.ScenarioAttribute Build(IEnumerator<parser.token.ITokenable> tokens, IScenarioNode now, ScenarioData scenarioData)
        {
            String name = tokens.Current.GetToken();
            tokens.MoveNext();
            if ((tokens.Current.GetType() != parser.token.TokenType.Equal) || (!tokens.MoveNext()))
            {
                throw new SyntaxErrorException("NotMatch:" + name);
            }

            if ((tokens.Current.GetType() != parser.token.TokenType.DoubleQuotation) || (!tokens.MoveNext()))
            {
                throw new SyntaxErrorException("NeedDoubleQuotation:" + tokens.Current.ToString());
            }


            String value = tokens.Current.GetToken();
            tokens.MoveNext();

            //  ""の中に空白があるかもしれないので"がくるまでループする
            while (tokens.Current.GetType() != parser.token.TokenType.DoubleQuotation)
            {
                value += " " + tokens.Current.GetToken();
                tokens.MoveNext();
            }

            tokens.MoveNext();

            return new ScenarioAttribute(name, value);
        }
    }
}
