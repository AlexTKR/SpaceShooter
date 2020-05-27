namespace Scripts.LevelGeneration
{
    public class LevelGenerationController : LevelGenerationControllerBase
    {
        private LevelGeneratorBase levelGenerator;
        private LevelGenerationDataBase levelGenerationData;

        public LevelGenerationController(LevelGenerationDataBase _levelGenerationData)
        {
            levelGenerationData = _levelGenerationData;
        }

        public override void Init()
        {
            InitLevelGenerator();
        }

        private void InitLevelGenerator()
        {
            levelGenerator = new LevelGenerator(levelGenerationData);
        }
    }
}