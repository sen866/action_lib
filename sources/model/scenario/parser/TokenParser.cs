using action_game.sources.model.scenario.parser.token;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace action_game.sources.model.scenario.parser
{
    class TokenParser
    {
        public static List<ITokenable> Parse(String text)
        {
            var results = new List<ITokenable>();


            String buffer = "";
            for (var c = text.GetEnumerator(); c.MoveNext(); )
            {
                //  1文字でデリミタに一致しているか
                if (Tokenizer.IsDelimiter(c.Current))
                {
                    //  一致している場合はそれまでの分と今回のをtokenに変換
                    if (String.Empty != buffer)
                    {
                        var token = Tokenizer.Convert(buffer);

                        buffer = "";
                        results.Add(token);
                    }

                    {
                        var token = Tokenizer.Convert(Convert.ToString(c.Current));

                        if (token != null)
                        {
                            results.Add(token);
                        }
                    }
                    continue;
                }

                buffer += c.Current;
            }

            //  いけてないけど最後にトークンのNextを設定する
            {
                var enumerator = results.GetEnumerator();
                var now = enumerator.Current;
                while (enumerator.MoveNext())
                {
                    if (now != null)
                    {
                        now.Next = enumerator.Current;
                    }
                    now = enumerator.Current;
                }
            }

            return results;
        }
    }
}
