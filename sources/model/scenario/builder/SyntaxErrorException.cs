using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.scenario.builder
{
    class SyntaxErrorException : SystemException
    {
        public SyntaxErrorException()
            : base()
        {
        }

        public SyntaxErrorException(String message)
            : base(message)
        {
        }
    }
}
