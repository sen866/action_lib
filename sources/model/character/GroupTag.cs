using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.character
{
    public class GroupTag
    {
        public const String PLAYER_TAG = "Player";

        public GroupTag(String _tagString)
        {
            TagString = _tagString;
        }

        public String TagString { get; set; }
    }
}
