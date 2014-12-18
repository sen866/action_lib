using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.scenario
{
    public enum TextType
    {
        RightSay,
        CenterSay,
        LeftSay,
        RightShout,
        CenterShout,
        LeftShout,
        Normal,
    }

    public class ScenarioPlayer
    {
        public ScenarioPlayer()
        {
            CurrentText = "";

            leftSide = new List<ScenarioCharacter>();
            rightSide = new List<ScenarioCharacter>();
            centerSide = new List<ScenarioCharacter>();
        }

        public void Load(ScenarioData data)
        {
            this.data = data;
            current = this.data.ScenarioRoot.Next;
        }

        public void Update(float now)
        {
            DeltaTime = now - Now;
            Now = now;

            //  再生完了しているところまで進む
            skipPlayed();

            //  再生する
            play();
        }

        private void skipPlayed()
        {
            for (; current != null; )
            {
                if (current.GetExecutor() != null && !current.GetExecutor().IsPlayed(current))
                {
                    break;
                }
                current = current.Next;

                if(current == null)
                {
                    OnCompletePlay();
                }
            }
        }

        private void play()
        {
            if (current == null)
            {
                return;
            }
            if (current.GetExecutor() == null)
            {
                return;
            }
            current.GetExecutor().Play(this, current);
        }

        private ScenarioData data { get; set; }
        private IScenarioNode current { get; set; }

        public String CurrentText
        {
            get
            {
                return this.currentText;
            }

            private set
            {
                this.currentText = value;

                if (OnChangeText != null)
                {
                    OnChangeText(currentText);
                }
            }
        }

        public void StartNewText(TextType type, String name)
        {
            if (OnStartNewText != null)
            {
                OnStartNewText(type, name);
            }

            CurrentText = "";
        }

        public void AddText(String text)
        {
            CurrentText += text;
        }

        public void AddRightSide(ScenarioCharacter character)
        {
            rightSide.Add(character);
            if (null != OnAddRightSide)
            {
                OnAddRightSide(rightSide, character);
            }
        }

        public void AddLeftSide(ScenarioCharacter character)
        {
            leftSide.Add(character);
            if (null != OnAddLeftSide)
            {
                OnAddLeftSide(leftSide, character);
            }
        }

        public void AddCenterSide(ScenarioCharacter character)
        {
            centerSide.Add(character);
            if (null != OnAddCenterSide)
            {
                OnAddCenterSide(centerSide, character);
            }
        }

        public void RemoveRightSide(ScenarioCharacter character)
        {
            if (null != OnRemoveRightSide)
            {
                OnRemoveRightSide(rightSide);
            }
            rightSide.Clear();
        }

        public void RemoveLeftSide(ScenarioCharacter character)
        {
            if (null != OnRemoveLeftSide)
            {
                OnRemoveLeftSide(leftSide);
            }
            leftSide.Clear();
        }

        public void RemoveCenterSide(ScenarioCharacter character)
        {
            if (null != OnRemoveCenterSide)
            {
                OnRemoveCenterSide(centerSide);
            }
            centerSide.Clear();
        }

        private String currentText;

        private List<ScenarioCharacter> rightSide { get; set; }
        private List<ScenarioCharacter> leftSide { get; set; }
        private List<ScenarioCharacter> centerSide { get; set; }

        public float DeltaTime { get; private set; }
        public float Now { get; private set; }

        public event Action<TextType, String> OnStartNewText;
        public event Action<String> OnChangeText;
        public event Action<List<ScenarioCharacter>, ScenarioCharacter> OnAddRightSide;
        public event Action<List<ScenarioCharacter>, ScenarioCharacter> OnAddLeftSide;
        public event Action<List<ScenarioCharacter>, ScenarioCharacter> OnAddCenterSide;
        public event Action<List<ScenarioCharacter>> OnRemoveRightSide;
        public event Action<List<ScenarioCharacter>> OnRemoveLeftSide;
        public event Action<List<ScenarioCharacter>> OnRemoveCenterSide;
        public event Action OnCompletePlay = delegate { };
    }
}
