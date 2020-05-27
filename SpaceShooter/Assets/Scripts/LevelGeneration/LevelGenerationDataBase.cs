using UnityEngine;

namespace Scripts.LevelGeneration
{
    public abstract class LevelGenerationDataBase : ScriptableObject
    {
        public abstract int MinLevelCount { get; }
        public abstract int MaxLevelCount { get; }
    }
}