using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.scenario.parser.token
{
    class Word : ITokenable
    {
        public Word(String text)
        {
            Text = text;
        }

        public override String ToString()
        {
            return Text;
        }

        public String GetToken()
        {
            return Text;
        }

        public String Text { get; set; }

        TokenType ITokenable.GetType()
        {
            return TokenType.Word;
        }

        public ITokenable Next { get; set; }
    }
}
