using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.scenario.parser.token
{
    public enum TokenType
    {
        Word,
        Equal,
        LeftArrow,
        RightArrow,
        Slash,
        DoubleQuotation,
    }

    public interface ITokenable
    {
        TokenType GetType();
        String GetToken();

        ITokenable Next { get; set; }
    }
}
