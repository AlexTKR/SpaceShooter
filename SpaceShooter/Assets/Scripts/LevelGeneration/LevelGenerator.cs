using System.IO;

namespace Scripts.LevelGeneration
{
    public class LevelGenerator : LevelGeneratorBase
    {
        private LevelGenerationDataBase levelGenerationData;

        public LevelGenerator(LevelGenerationDataBase _levelGenerationData)
        {
            levelGenerationData = _levelGenerationData;
        }

        public override void Generate()
        {

        }

        private void GenerateLevels()
        {
            if (Directory.Exists(Utilities.Utilities.savePath))
            {
                //Load game
            }
            else
            {
                //Create levels from scratch
            }
        }
    }
}