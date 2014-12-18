using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.scenario.builder.command
{
    class Character : ICommandable
    {
        public bool HasEndTag()
        {
            return true;
        }

        public bool IsSyntax(IEnumerator<parser.token.ITokenable> tokens)
        {
            throw new NotImplementedException();
        }

        public IScenarioNode Build(IEnumerator<parser.token.ITokenable> tokens, IScenarioNode now, ScenarioData scenarioData)
        {
            var result = new ScenarioElement();

            //  attribute解析
            while (tokens.Current.GetType() != parser.token.TokenType.RightArrow)
            {
                var attribute = new Attribute();
                result.AddAttribute(attribute.Build(tokens, result, scenarioData));
            }

            tokens.MoveNext();

            //  子要素 img命令が0回以上続く
            var image = new Image();
            for (; image.IsSyntax(tokens); )
            {
                var tag = new Tag();
                result.AddChild(tag.Build(tokens, now, scenarioData));
            }


            return result;
        }
    }
}
