using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.utility
{
    public class WaitTimer
    {
        public WaitTimer(float _waitingTime, Action _onExecute)
        {
            waitingTime = _waitingTime;

            Updater.OnUpdate += onUpdate;

            elapsedTime = 0.0f;

            onExecute = _onExecute;
        }

        private void onUpdate(float deltaTime)
        {
            elapsedTime += deltaTime;

            if (waitingTime <= elapsedTime)
            {
                Updater.OnUpdate -= onUpdate;

                onExecute();

                onExecute = null;
            }
        }

        private float waitingTime { get; set; }

        private float elapsedTime { get; set; }

        private Action onExecute;
    }
}
