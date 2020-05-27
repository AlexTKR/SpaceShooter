using UnityEngine;

namespace Scripts.LevelGeneration
{
    [CreateAssetMenu(menuName =" LevelGenerationData", fileName = "LevelGenerationData")]
    public class LevelGenerationData : LevelGenerationDataBase
    {
        [SerializeField] private int minLevelCount;
        [SerializeField] private int maxLevelCount;

        public override int MinLevelCount => minLevelCount;
        public override int MaxLevelCount => maxLevelCount;
    }
}