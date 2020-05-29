using Scripts.Spawnable;
using UnityEngine;

namespace Scripts.LevelGeneration
{
    [CreateAssetMenu(menuName = " LevelGenerationData", fileName = "LevelGenerationData")]
    public class LevelGenerationData : LevelGenerationDataBase
    {
        [SerializeField] private int minLevelCount;
        [SerializeField] private int maxLevelCount;
        [SerializeField] private float minSpawnRate;
        [SerializeField] private float maxSpawnRate;
        [SerializeField] private int minSpawnableCount;
        [SerializeField] private int maxSpawnableCount;
        [SerializeField] private float minLevelDuration;
        [SerializeField] private float durationIncreasePerLevel;
        [SerializeField] private string levelOneName;
        [SerializeField] private SpawnableDataBase spawnableData;

        public override int MinLevelCount => minLevelCount;
        public override int MaxLevelCount => maxLevelCount;
        public override float MinLevelDuration => minLevelDuration;  
        public override float DurationIncreasePerLevel => durationIncreasePerLevel;
        public override int MinSpawnableCount => minSpawnableCount;
        public override int MaxSpawnableCount => maxSpawnableCount;
        public override SpawnableDataBase SpawnableData => spawnableData;
        public override string LevelOneName => levelOneName;
        public override float MinSpawnRate => minSpawnRate;
        public override float MaxSpawnRate => maxSpawnRate;
    }
}