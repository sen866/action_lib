using action_game.OGamesProject.sources.model.character;
using action_game.sources.model.character.item;
using action_game.sources.model.character.state;
using action_game.sources.model.skill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.character
{
    public interface ICharacterable : IMovable, IStateChangable
    {
        Executioner Executioner { get; set; }
        SkillHolder SkillHolder { get; set; }
        PickupItemHolder PickupItemHolder { get; set; }
        EquipItemHolder EquipItemHolder { get; set; }
        BattleCharacter BattleCharacter { get; set; }

        float RunMaxSpeed { get; set; }
        GroupId GroupId { get; set; }
        GroupTag GroupTag { get; set; }

        void update(float now, float deltaTime);
    }
}
