using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Scripts.Spawnable;
using Scripts.Pools;
using Scripts.Factories;

namespace Scripts.Levels
{
    public class LevelSpawner : LevelSpawnerBase
    {
        private LevelViewBase levelView;
        private LevelHolderBase levelHolder;
        private AsteroidsFactoryBase asteroidsFactory;
        private MonoBehaviour mono;

        private LevelBase currentLevel;
        private GenericPool<SpawnableBase> currentPool;
        private Dictionary<string, GenericPool<SpawnableBase>> poolHolder;

        public LevelSpawner(LevelViewBase _levelView, LevelHolderBase _levelHolder, AsteroidsFactoryBase _asteroidsFactory, MonoBehaviour _mono)
        {
            levelView = _levelView;
            levelHolder = _levelHolder;
            asteroidsFactory = _asteroidsFactory;
            mono = _mono;
        }

        public override void Init()
        {
            InitPools();
        }

        public override void SetCurrentLevel(LevelBase level)
        {
            currentLevel = level;
        }

        public override void StartSpawning()
        {
            currentPool = poolHolder[currentLevel.LevelData.levelName];
            mono.StartCoroutine(Spawn());
        }

        public override void StopSpawning()
        {
            mono.StopAllCoroutines();
        }

        private void InitPools()
        {
            poolHolder = new Dictionary<string, GenericPool<SpawnableBase>>();

            if (levelHolder.Levels.Count != 0)
            {
                LinkedListNode<LevelBase> head = levelHolder.Levels.First;

                while (head != null)
                {
                    GenericPool<SpawnableBase> asteroidsPool = new AsteroidsPool();
                    asteroidsPool.InitiatePool();
                    poolHolder.Add(head.Value.LevelData.levelName, asteroidsPool);

                    head = head.Next;
                }
            }
        }

        private IEnumerator Spawn()
        {
            while (true)
            {
                if (currentPool.IsPoolEmpty() == true)
                {
                    PopulatePool();
                }

                SpawnableBase currAsteroid = currentPool.GetInctance();
                currAsteroid.SetPool(currentPool);
                currAsteroid.transform.position = levelView.SpawnPos[Random.Range(0, levelView.SpawnPos.Count)].position;
                currAsteroid.gameObject.SetActive(true);

                yield return new WaitForSecondsRealtime(3f);
            }

        }

        private void PopulatePool()
        {
            for (int i = 0; i < currentLevel.LevelData.spawnables.Count; i++)
            {
                SpawnableBase currAsteroid = asteroidsFactory.GetItem(currentLevel.LevelData.spawnables[i]);
                currAsteroid.gameObject.transform.SetParent(levelView.SpawnableHolder);
                currAsteroid.gameObject.SetActive(false);
                currentPool.SetInstance(currAsteroid);
            }
        }
    }
}