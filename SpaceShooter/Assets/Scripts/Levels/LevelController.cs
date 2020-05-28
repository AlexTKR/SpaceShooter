using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Levels
{
    public class LevelController : LevelControllerBase
    {
        private LevelHolderBase levelHolder;
        private LevelSpawnerBase levelSpawner;
        private MonoBehaviour mono;

        public LevelController(LevelHolderBase _levelHolder, MonoBehaviour _mono)
        {
            levelHolder = _levelHolder;
            mono = _mono;
        }

        public override void Init()
        {
            InitLevels();
        }

        public override void StartLevel(LevelBase level)
        {
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