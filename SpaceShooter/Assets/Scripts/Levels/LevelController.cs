using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scripts.Player;

namespace Scripts.Levels
{
    public class LevelController : LevelControllerBase
    {
        private LevelHolderBase levelHolder;
        private PlayerControllerBase playerController;
        private MonoBehaviour mono;

        private LevelSpawnerBase levelSpawner;
        private LevelBase currentLevel;

        public LevelController(LevelHolderBase _levelHolder, MonoBehaviour _mono, PlayerControllerBase _playerController)
        {
            playerController = _playerController;
            levelHolder = _levelHolder;
            mono = _mono;
        }

        public override void Init()
        {
            InitLevels();
            InitLevelSpawner();
        }

        public override void StartLevel(LevelBase level)
        {
            currentLevel = level;
            mono.StartCoroutine(StartLevel());
        }

        public override void Tick()
        {
            
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
            levelSpawner = new LevelSpawner();
        }

        private IEnumerator StartLevel()
        {
            yield return null;
        }
    }
}