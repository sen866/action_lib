using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.utility
{
    static public class Updater
    {
        static public event Action<float> OnUpdate = delegate { };

        static public event Action<float> OnFixedUpdate = delegate { };

        static public event Action<float> OnLastUpdate = delegate { };

        static public void Update(float deltaTime)
        {
            OnUpdate(deltaTime);
        }

        static public void FixedUpdate(float deltaTime)
        {
            OnFixedUpdate(deltaTime);
        }

        static public void LastUpdate(float deltaTime)
        {
            OnLastUpdate(deltaTime);
        }
    }
}
