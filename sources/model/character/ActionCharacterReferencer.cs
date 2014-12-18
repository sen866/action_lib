using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.character
{
    public static class ActionCharacterReferencer
    {
        static ActionCharacterReferencer()
        {
            actionCharacters = new Dictionary<Guid, ActionCharacter>();
        }

        public static void Add(ActionCharacter character)
        {
            actionCharacters.Add(character.Id, character);
        }

        public static void Remove(ActionCharacter character)
        {
            actionCharacters.Remove(character.Id);
        }

        public static Dictionary<Guid, ActionCharacter> Get()
        {
            return actionCharacters;
        }

        private static Dictionary<Guid, ActionCharacter> actionCharacters { get; set; }
    }
}
