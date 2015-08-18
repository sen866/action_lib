using action_game.sources.model.character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.character.player
{
    static public class PlayerHolder
    {
        static PlayerHolder()
        {
        }

        static private ActionCharacter player;

        static public ActionCharacter Player
        {
            set
            {
                player = value;
                Copy();
            }
            get { return player; }
        }

        static public void Copy()
        {
            if (null == player)
            {
                return;
            }
            CopyedStatus = player.BattleCharacter.BattleStatus.Clone();
        }

        static public void Revert()
        {
            if (null == player)
            {
                return;
            }
            player.BattleCharacter.BattleStatus = CopyedStatus.Clone();

            //  TODO::本当はアイテムも戻さないとだめだな
        }

        static public void Reset()
        {
            CopyedStatus = null;
        }

        static public BattleStatus CopyedStatus { get; private set; }
    }
}
