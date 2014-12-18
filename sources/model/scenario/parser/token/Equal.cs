using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.scenario.parser.token
{
    class Equal : ITokenable
    {
        TokenType ITokenable.GetType()
        {
            return TokenType.Equal;
        }


        string ITokenable.GetToken()
        {
            throw new NotImplementedException();
        }

        public ITokenable Next { get; set; }
    }
}
