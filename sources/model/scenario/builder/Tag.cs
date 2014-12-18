using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.scenario.builder
{
    public class Tag : IScenarioNodeBuildable
    {
        public IScenarioNode Build(IEnumerator<parser.token.ITokenable> tokens, IScenarioNode now, ScenarioData scenarioData)
        {
            IScenarioNode result = null;

            //  タグの定義< word /> or <word> ... </word>
            if ((tokens.Current.GetType() != parser.token.TokenType.LeftArrow) || !tokens.MoveNext())
            {
                //  シンタックスエラー
                throw new SyntaxErrorException();
            }

            if ((tokens.Current.GetType() != parser.token.TokenType.Word))
            {
                //  シンタックスエラー
                throw new SyntaxErrorException();
            }

            var startWord = tokens.Current.GetToken();

            if (!tokens.MoveNext())
            {
                //  シンタックスエラー
                throw new SyntaxErrorException();
            }

            //  中身
            var builder = Command.Create(startWord);

            result = builder.Build(tokens, now, scenarioData);

            //  ここまでは共通でここから先は異なるはず
            if (!builder.HasEndTag())
            {
                //  一つ目のパターンのはず

                //  Endタグ
                if ((tokens.Current.GetType() != parser.token.TokenType.RightArrow))
                {
                    //  シンタックスエラー
                    throw new SyntaxErrorException("NotRightArrow:" + tokens.Current.ToString());
                }
                tokens.MoveNext();
            }
            else
            {
                //  二つ目のパターンのはず
                //  Endタグ
                if ((tokens.Current.GetType() != parser.token.TokenType.LeftArrow) || !tokens.MoveNext())
                {
                    //  シンタックスエラー
                    throw new SyntaxErrorException("NotLeftArrow:" + tokens.Current.ToString() + startWord + tokens.Current.Next.ToString());
                }
                if ((tokens.Current.GetType() != parser.token.TokenType.Slash) || !tokens.MoveNext())
                {
                    //  シンタックスエラー
                    throw new SyntaxErrorException("NotSlash:" + startWord + tokens.Current.Next.ToString());
                }
                //  開始タグと一致しなければエラー
                if ((tokens.Current.GetType() != parser.token.TokenType.Word) ||(startWord != tokens.Current.GetToken()) || !tokens.MoveNext())
                {
                    throw new SyntaxErrorException("NotMatchWord:" + tokens.Current.ToString());
                }

                if ((tokens.Current.GetType() != parser.token.TokenType.RightArrow))
                {
                    //  シンタックスエラー
                    throw new SyntaxErrorException("NotRightArrow:" + tokens.Current.ToString());
                }

                tokens.MoveNext();
            }

            return result;
        }

        public bool IsSyntax(IEnumerator<parser.token.ITokenable> tokens)
        {
            throw new NotImplementedException();
        }
    }
}
