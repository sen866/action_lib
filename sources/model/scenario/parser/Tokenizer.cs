using action_game.sources.model.scenario.parser.token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.scenario.parser
{
    class Tokenizer
    {
        public static ITokenable Convert(String dest)
        {
            if (dest.Length == 1 && Char.IsWhiteSpace(dest, 0))
            {
                return null;
            }

            switch (dest)
            {
                case "=": return new Equal();
                case "<": return new LeftArrow();
                case ">": return new RightArrow();
                case "/": return new token.Slash();
                case "\"": return new DoubleQuotation();
            }
            return new Word(dest);
        }

        public static bool IsDelimiter(char c)
        {
            if (Char.IsWhiteSpace(c))
            {
                return true;
            }

            switch (c)
            {
                case '=':
                case '<':
                case '>':
                case '/':
                case '"':
                    return true;
            }

            return false;
        }
    }
}
