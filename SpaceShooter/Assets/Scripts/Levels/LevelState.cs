namespace Scripts.Levels
{
    public class LevelState : LevelStateBase
    {
        private LevelBase level;

        public LevelState(LevelBase _level)
        {
            level = _level;
        }

        public override LevelBase Level => level;
    }
}