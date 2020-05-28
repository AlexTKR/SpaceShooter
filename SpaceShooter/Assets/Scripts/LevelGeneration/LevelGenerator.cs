using UnityEngine;
using System.IO;
using Scripts.Levels;
using System.Collections.Generic;
using System.Linq;

namespace Scripts.LevelGeneration
{
    public class LevelGenerator : LevelGeneratorBase
    {
        private LevelGenerationDataBase levelGenerationData;
        private LevelHolderBase levelHolder;

        public LevelGenerator(LevelGenerationDataBase _levelGenerationData, LevelHolderBase _levelHolder)
        {
            levelGenerationData = _levelGenerationData;
            levelHolder = _levelHolder;
        }

        public override void Generate()
        {
            GenerateLevels();
        }

        private void GenerateLevels()
        {
            if (Directory.Exists(Utilities.Utilities.savePath))
            {
                //Load game
            }
            else
            {
                CreateLevels();
            }
        }

        private void CreateLevels()
        {
            int levelNumber = 1;
            float durationIncrease = 0;

            for (int i = 0; i < Random.Range(levelGenerationData.MinLevelCount, levelGenerationData.MaxLevelCount); i++)
            {
                LevelDataBase levelData = new LevelData();
                levelData.LevelName = "Level" + levelNumber;
                levelData.LevelDuration = levelGenerationData.MinLevelDuration + durationIncrease;

                for (int j = 0; j < levelGenerationData.MaxSpawnableCount; j++)
                {
                    levelData.Spawnables.Add(levelGenerationData.SpawnableData.Spawnables[Random.Range(0, levelGenerationData.SpawnableData.Spawnables.Count)].name);
                }

                LevelBase level = new Level(levelData);
                levelHolder.Levels.AddLast(level);

                levelNumber++;
                durationIncrease += levelGenerationData.DurationIncreasePerLevel;
            }
        }
    }
}