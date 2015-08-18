using action_game.OGamesProject.sources.model.character;
using action_game.sources.model.character.item;
using action_game.sources.model.skill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.character.player
{
    public static class PlayerInitializer
    {
        static PlayerInitializer()
        {
        }

        public static void Initialize(float speed, BattleStatus status, List<ISkill> skills)
        {
            var player = new ActionCharacter(
                status: status,
                groupId: GroupId.PLAYER,
                tag: new GroupTag(GroupTag.PLAYER_TAG),
                pos: new Vector(),
                gravity: 20.0f,
                runSpeed: speed,
                skillHolder: new SkillHolder(skills),
                equipItemHolder: new EquipItemHolder(new Weapon(new BattleStatus()))
                );

            PlayerHolder.Player = player;

            ActionCharacterReferencer.Add(player);
        }
    }
}
