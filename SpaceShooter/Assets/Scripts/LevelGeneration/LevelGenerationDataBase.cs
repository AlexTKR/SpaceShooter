using UnityEngine;
using Scripts.Spawnable;

namespace Scripts.LevelGeneration
{
    public abstract class LevelGenerationDataBase : ScriptableObject
    {
        public abstract int MinLevelCount { get; }
        public abstract int MaxLevelCount { get; }
        public abstract int MinSpawnableCount { get; }
        public abstract int MaxSpawnableCount { get; }
        public abstract float MinLevelDuration { get; }
        public abstract float DurationIncreasePerLevel { get; }
        public abstract SpawnableDataBase SpawnableData { get; }
    }
}