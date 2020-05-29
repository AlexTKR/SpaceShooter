namespace Scripts.Levels
{
    public abstract class LevelSpawnerBase 
    {
        public abstract void SetCurrentLevel(LevelBase level);
        public abstract void StartSpawning();
        public abstract void StopSpawning();
        public abstract void Init();
    }
}