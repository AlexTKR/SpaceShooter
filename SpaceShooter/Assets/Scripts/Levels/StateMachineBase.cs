using System;

namespace Scripts.Levels
{
    public abstract class StateMachineBase 
    {
        public abstract void Init();
        public abstract void SetState(LevelStateBase levelState);
        public abstract void ChangeState(LevelStateBase levelState);
        public abstract void Tick();
    }
}
