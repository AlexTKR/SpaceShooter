using System;
using System.Collections.Generic;

namespace Scripts.Levels
{
    public class StateMachine : StateMachineBase
    {
        private List<LevelStateBase> levelStatesHolder;
        private LevelStateBase currentLevelState;

        public override void ChangeState(LevelStateBase levelState)
        {
            if (levelStatesHolder.Contains(levelState))
            {
                currentLevelState = levelState;
            }
        }

        public override void Init()
        {
            InitStateHolder();
        }

        public override void SetState(LevelStateBase levelState)
        {
            levelStatesHolder.Add(levelState);
        }

        public override void Tick()
        {
            throw new NotImplementedException();
        }

        private void InitStateHolder()
        {
            levelStatesHolder = new List<LevelStateBase>();
        }
    }
}