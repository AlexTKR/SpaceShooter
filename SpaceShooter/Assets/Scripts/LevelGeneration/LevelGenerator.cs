using UnityEngine;
using System.IO;
using Scripts.Levels;
using System.Collections.Generic;

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
                // put prefabs in there + you can create states at run time 
                LevelBase level = new Level(levelData);
                levelHolder.Levels.AddLast(level);

                levelNumber++;
                durationIncrease += levelGenerationData.DurationIncreasePerLevel;
            }
        }
    }
}