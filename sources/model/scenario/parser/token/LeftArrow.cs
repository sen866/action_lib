using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.scenario.parser.token
{
    class LeftArrow : ITokenable
    {
        TokenType ITokenable.GetType()
        {
            return TokenType.LeftArrow;
        }


        string ITokenable.GetToken()
        {
            throw new NotImplementedException();
        }

        public ITokenable Next { get; set; }
    }
}
