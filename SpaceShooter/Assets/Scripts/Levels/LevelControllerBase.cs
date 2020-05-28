namespace Scripts.Levels
{
    public abstract class LevelControllerBase 
    {
        public abstract void Init();
        public abstract void Tick();

        public abstract void StartLevel(LevelBase level);
    }
}