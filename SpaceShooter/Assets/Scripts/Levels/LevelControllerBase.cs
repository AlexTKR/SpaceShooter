namespace Scripts.Levels
{
    public abstract class LevelControllerBase 
    {
        public abstract void Init();

        public abstract void StartLevel(LevelBase level);
        public abstract void StopLevel();
    }
}