using action_game.sources.model.scenario.parser.token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.scenario.parser.token
{
    class DoubleQuotation : ITokenable
    {
        TokenType ITokenable.GetType()
        {
            return TokenType.DoubleQuotation;
        }


        string ITokenable.GetToken()
        {
            throw new NotImplementedException();
        }

        public ITokenable Next { get; set; }
    }
}
