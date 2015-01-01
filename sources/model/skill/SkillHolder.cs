using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.skill
{
    public class SkillHolder
    {
        public SkillHolder(List<ISkill> normals)
        {
            Normals = new List<ISkill>(normals);

            ResetCurrent();
        }

        public void ResetCurrent()
        {
            CurrentPosition = Normals.GetEnumerator();

            CurrentPosition.MoveNext();

            Current = CurrentPosition.Current;
        }

        public void MoveNextNormal()
        {
            if (CurrentPosition.MoveNext())
            {
                Current = CurrentPosition.Current;
            }
            else
            {
                Current = null;
            }
        }

        public ISkill Current { get; set; }

        public List<ISkill> Normals { get; set; }

        public IEnumerator<ISkill> CurrentPosition { get; set; }
    }
}
