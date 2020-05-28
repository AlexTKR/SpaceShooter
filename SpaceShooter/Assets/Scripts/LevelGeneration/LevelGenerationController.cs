using Scripts.Levels;

namespace Scripts.LevelGeneration
{
    public class LevelGenerationController : LevelGenerationControllerBase
    {
        private LevelGeneratorBase levelGenerator;
        private LevelGenerationDataBase levelGenerationData;
        private LevelHolderBase levelHolder;

        public LevelGenerationController(LevelGenerationDataBase _levelGenerationData, LevelHolderBase _levelHolder)
        {
            levelGenerationData = _levelGenerationData;
            levelHolder = _levelHolder;
        }

        public override void Init()
        {
            InitLevelGenerator();
        }
        
        private void InitLevelGenerator()
        {
            levelGenerator = new LevelGenerator(levelGenerationData, levelHolder);
            levelGenerator.Generate();
        }
    }
}