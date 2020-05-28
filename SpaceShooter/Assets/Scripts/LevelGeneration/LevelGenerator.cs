using UnityEngine;
using System.IO;
using Scripts.Levels;
using Scripts.Factories;
using Scripts.Map;

namespace Scripts.LevelGeneration
{
    public class LevelGenerator : LevelGeneratorBase
    {
        private LevelControllerBase levelController;
        private LevelGenerationDataBase levelGenerationData;
        private LevelHolderBase levelHolder;
        private SimpleFactory<LevelViewBase> levelViewFactory;
        private MapViewBase mapView;

        private string levelOneName = "Level1";

        public LevelGenerator(LevelControllerBase _levelController, LevelGenerationDataBase _levelGenerationData, LevelHolderBase _levelHolder, SimpleFactory<LevelViewBase> _levelViewFactory
            , MapViewBase _mapView)
        {
            levelController = _levelController;
            levelGenerationData = _levelGenerationData;
            levelHolder = _levelHolder;
            levelViewFactory = _levelViewFactory;
            mapView = _mapView;
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
                LevelData levelData = new LevelData(); //TODO make level data abstract. Can we binary serialize abstracts even thought we have to cast it anyway? 
                levelData.Init();
                levelData.levelName = "Level" + levelNumber;
                levelData.levelDuration = levelGenerationData.MinLevelDuration + durationIncrease;
                levelData.levelStatus = LevelStatus.Closed;

                if (levelData.levelName.Equals(levelOneName))
                {
                    levelData.levelStatus = LevelStatus.Open;
                }

                for (int j = 0; j < Random.Range(levelGenerationData.MinSpawnableCount, levelGenerationData.MaxSpawnableCount); j++)
                {
                    levelData.spawnables.Add(levelGenerationData.SpawnableData.Spawnables[Random.Range(0, levelGenerationData.SpawnableData.Spawnables.Count)].name);
                }

                LevelViewBase levelView = levelViewFactory.GetItem();
                levelView.gameObject.transform.SetParent(mapView.LevelViewHolder);

                LevelBase level = new Level(levelController ,levelData, levelView);
                levelHolder.Levels.AddLast(level);

                levelNumber++;
                durationIncrease += levelGenerationData.DurationIncreasePerLevel;
            }
        }
    }
}