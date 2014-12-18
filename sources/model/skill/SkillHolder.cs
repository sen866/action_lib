using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.skill
{
    public class SkillHolder
    {
        public SkillHolder(ISkill normal)
        {
            Normal = normal;

            Current = Normal;
        }

        public ISkill Current { get; set; }

        public ISkill Normal { get; set; }
    }
}
