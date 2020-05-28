namespace Scripts.Levels
{
    public class LevelSpawner : LevelSpawnerBase
    {
        LevelBase currentLevel;

        public LevelSpawner()
        {

        }

        public override void SetCurrentLevel(LevelBase level)
        {
            currentLevel = level;
        }

        public override void StartSpawning()
        {
            
        }

        public override void StopSpawning()
        {
            
        }
    }
}