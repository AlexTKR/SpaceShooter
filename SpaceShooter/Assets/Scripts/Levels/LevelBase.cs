namespace Scripts.Levels
{
    public abstract class LevelBase
    {
        public abstract void Init();
        public abstract void SetStatus();

        public abstract LevelData LevelData { get; }
    }
}