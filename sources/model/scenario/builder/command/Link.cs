using action_game.sources.model.file;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace action_game.sources.model.scenario.builder.command
{
    class Link : ICommandable
    {
        public bool HasEndTag()
        {
            return false;
        }

        public IScenarioNode Build(IEnumerator<parser.token.ITokenable> tokens, IScenarioNode now, ScenarioData scenarioData)
        {
            var result = new ScenarioElement();

            while(tokens.Current.GetType() != parser.token.TokenType.Slash)
            {
                var attribute = new Attribute();
                result.AddAttribute(attribute.Build(tokens, result, scenarioData));
            }


            //  とりあえずtype = charactersのみ対応しとこ
            //  href要素を探す
            if (result.GetAttribute("type").Value != "characters")
            {
                throw new NotSupportedException();
            }
            var href = result.GetAttribute("href");

            var linkData = loadLinkData(href.Value);

            //  んーどこでやるか悩むけどここでキャラ構築やっちゃうか
            for (var character = linkData.ScenarioRoot.Next; character != null; )
            {
                var scenarioCharacter = new ScenarioCharacter(character.GetAttribute("id").Value, character.GetAttribute("name").Value);

                //foreach (var image in character.GetChildren())
                {
                    //scenarioCharacter.AddImage(image.GetAttribute("type").Value, image.GetAttribute("src").Value);
                }

                scenarioData.Characters.Add(scenarioCharacter);
                character = character.Next;
            }

            return result;
        }

        public bool IsSyntax(IEnumerator<parser.token.ITokenable> tokens)
        {
            throw new NotImplementedException();
        }

        private static ScenarioData loadLinkData(String href)
        {
            var path = FilePathSearcher.FindPath(FilePathSearcher.FileType.Scenario, href);
            var bytes = File.ReadAllBytes(path);
            var text = GetEncoding.GetCode(bytes).GetString(bytes);

            var scenarioData = ScenarioLoader.LoadFromText(text);

            return scenarioData;
        }
    }
}
