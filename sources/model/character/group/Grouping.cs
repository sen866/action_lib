using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.character.group
{
    public static class Grouping
    {
        public static List<ActionCharacter> SearchEnemyGroup(ICharacterable own)
        {
            var characters = ActionCharacterReferencer.Get()
            .Select(_ => _.Value)
            .Where(_ => _.GroupId != own.GroupId);

            return new List<ActionCharacter>(characters);
        }
    }
}
