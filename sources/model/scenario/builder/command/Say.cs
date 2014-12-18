using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.scenario.builder.command
{
    class Say : ICommandable
    {
        public bool HasEndTag()
        {
            return true;
        }

        public IScenarioNode Build(IEnumerator<parser.token.ITokenable> tokens, IScenarioNode now, ScenarioData scenarioData)
        {
            var result = new ScenarioElement(
                new executor.Say()
                );

            //  attribute解析
            while (tokens.Current.GetType() != parser.token.TokenType.RightArrow)
            {
                var attribute = new Attribute();
                result.AddAttribute(attribute.Build(tokens, result, scenarioData));
            }

            tokens.MoveNext();


            //  子要素
            //  0回以上NewLine or WaitNext or テキストが続く
            while (true)
            {
                var textBuilder = new Text();
                if (textBuilder.IsSyntax(tokens))
                {
                    result.AddChild(textBuilder.Build(tokens, result, scenarioData));
                    continue;
                }

                var newLineBuilder = new NewLine();
                if (newLineBuilder.IsSyntax(tokens))
                {
                    result.AddChild(newLineBuilder.Build(tokens, result, scenarioData));
                    continue;
                }

                var waitNextBuilder = new WaitNext();
                if (waitNextBuilder.IsSyntax(tokens))
                {
                    result.AddChild(waitNextBuilder.Build(tokens, result, scenarioData));
                    continue;
                }

                var comment = new Comment();
                if (comment.IsSyntax(tokens))
                {
                    var tag = new Tag();
                    result.AddChild(tag.Build(tokens, result, scenarioData));

                    continue;
                }

                break;
            }
            return result;
        }

        public bool IsSyntax(IEnumerator<parser.token.ITokenable> tokens)
        {
            throw new NotImplementedException();
        }
    }
}
