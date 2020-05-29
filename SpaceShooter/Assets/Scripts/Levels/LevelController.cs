using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scripts.Player;
using Scripts.Factories;
using Scripts.Map;

namespace Scripts.Levels
{
    public class LevelController : LevelControllerBase
    {
        private LevelViewBase levelView;
        private LevelHolderBase levelHolder;
        private PlayerControllerBase playerController;
        private PlayerDataBase PlayerData;
        private MonoBehaviour mono;
        private AsteroidsFactoryBase asteroidsFactory;
        private MapControllerBase mapController;

        private LevelSpawnerBase levelSpawner;
        private LevelBase currentLevel;

        public LevelController(LevelViewBase _levelView, LevelHolderBase _levelHolder, MonoBehaviour _mono, 
            PlayerControllerBase _playerController, PlayerDataBase _PlayerData , AsteroidsFactoryBase _asteroidsFactory, MapControllerBase _mapController)
        {
            levelView = _levelView;
            playerController = _playerController;
            PlayerData = _PlayerData;
            levelHolder = _levelHolder;
            mono = _mono;
            asteroidsFactory = _asteroidsFactory;
            mapController = _mapController;
        }

        public override void Init()
        {
            InitLevels();
            InitLevelSpawner();
        }

        public override void StartLevel(LevelBase level)
        {
            currentLevel = level;
            mapController.Disable();
            playerController.Enable();
            mono.StartCoroutine(StartLevel());
        }

        public override void StopLevel()
        {
            playerController.Disable();
            mono.StopAllCoroutines();
            levelSpawner.StopSpawning();
            mapController.Enable();
        }

        private void InitLevels()
        {
            if (levelHolder.Levels.Count != 0)
            {
                LinkedListNode<LevelBase> head = levelHolder.Levels.First;

                while (head != null)
                {
                    head.Value.Init();
                    head = head.Next;
                }
            }
        }

        private void InitLevelSpawner()
        {
            levelSpawner = new LevelSpawner(levelView, levelHolder, asteroidsFactory, mono);
            levelSpawner.Init();
        }

        private IEnumerator StartLevel()
        {
            levelSpawner.SetCurrentLevel(currentLevel);

            float levelDuration = currentLevel.LevelData.levelDuration;
            levelSpawner.StartSpawning();

            while (levelDuration > 0)
            {
                yield return new WaitForSecondsRealtime(1f);
                levelDuration--;
                levelView.TimeText.text = levelDuration.ToString();

                if (PlayerData.PlayerLifes == 0)
                {
                    levelView.LoseText.gameObject.SetActive(true);
                    yield return new WaitForSecondsRealtime(2f);
                    levelView.LoseText.gameObject.SetActive(false);
                    StopLevel();
                }
            }

            playerController.Disable();
            currentLevel.LevelData.levelStatus = LevelStatus.Completed;
            currentLevel.SetStatus();

            LinkedListNode<LevelBase> nextLevel;
            nextLevel = levelHolder.Levels.Find(currentLevel).Next;

            if (nextLevel != null)
            {
                nextLevel.Value.LevelData.levelStatus = LevelStatus.Open;
                nextLevel.Value.SetStatus();
            }

            levelView.WinText.gameObject.SetActive(true);
            yield return new WaitForSecondsRealtime(2f);
            levelView.WinText.gameObject.SetActive(false);

            mapController.Enable();
            levelSpawner.StopSpawning();
        }
    }
}