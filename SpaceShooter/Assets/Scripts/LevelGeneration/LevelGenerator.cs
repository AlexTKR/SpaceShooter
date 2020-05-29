using UnityEngine;
using System.IO;
using Scripts.Levels;
using Scripts.Factories;
using Scripts.Map;
using Scripts.Saving;

namespace Scripts.LevelGeneration
{
    public class LevelGenerator : LevelGeneratorBase
    {
        private LevelControllerBase levelController;
        private LevelGenerationDataBase levelGenerationData;
        private LevelHolderBase levelHolder;
        private SimpleFactory<LevelIconBase> levelIconFactory;
        private MapViewBase mapView;

        private string levelOneName = "Level1"; //TODO move to level data

        public LevelGenerator(LevelControllerBase _levelController, LevelGenerationDataBase _levelGenerationData, LevelHolderBase _levelHolder, SimpleFactory<LevelIconBase> _levelIconFactory
            , MapViewBase _mapView)
        {
            levelController = _levelController;
            levelGenerationData = _levelGenerationData;
            levelHolder = _levelHolder;
            levelIconFactory = _levelIconFactory;
            mapView = _mapView;
        }

        public override void Generate()
        {
            GenerateLevels();
        }

        private void GenerateLevels()
        {
            if (File.Exists(Utilities.Utilities.savePath + "Save.save"))
            {
                LoadLevels();
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
                LevelData levelData = new LevelData(); 
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

                SaveData.Current.levelData.Add(levelData);

                LevelIconBase levelIcon = levelIconFactory.GetItem();
                levelIcon.gameObject.SetActive(true);
                levelIcon.gameObject.transform.SetParent(mapView.LevelViewHolder);

                LevelBase level = new Level(levelController ,levelData, levelIcon);
                levelHolder.Levels.AddLast(level);

                levelNumber++;
                durationIncrease += levelGenerationData.DurationIncreasePerLevel;
            }
        }

        private void LoadLevels()
        {
            SaveData.Current = (SaveData)SerializationManager.Load(Utilities.Utilities.savePath + "Save.save");

            for (int i = 0; i < SaveData.Current.levelData.Count; i++)
            {
                LevelIconBase levelIcon = levelIconFactory.GetItem();
                levelIcon.gameObject.SetActive(true);
                levelIcon.gameObject.transform.SetParent(mapView.LevelViewHolder);

                LevelBase level = new Level(levelController, SaveData.Current.levelData[i], levelIcon);
                levelHolder.Levels.AddLast(level);
            }
        }
    }
}