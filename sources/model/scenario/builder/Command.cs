using action_game.sources.model.scenario.builder.command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.scenario.builder
{
    class Command
    {
        public const String Link = "link";
        public const String Say = "say";
        public const String Right = "right";
        public const String Left = "left";
        public const String Center = "center";
        public const String NewLine = "br";
        public const String WaitNext = "l";
        public const String Character = "character";
        public const String Image = "img";
        public const String Background = "background";
        public const String p = "p";
        public const String Comment = "!--";

        public static ICommandable Create(String word)
        {
            switch (word)
            {
                case Link: return new Link();
                case Say: return new Say();
                case p: return new Say();
                case Right: return new Right();
                case Left: return new Left();
                case Center: return new Center();
                case NewLine: return new NewLine();
                case WaitNext: return new WaitNext();
                case Character: return new Character();
                case Image: return new Image();
                case Background: return new Background();
                case Comment: return new Comment();
            }
            throw new SyntaxErrorException("not found:" + word);
        }
    }
}
