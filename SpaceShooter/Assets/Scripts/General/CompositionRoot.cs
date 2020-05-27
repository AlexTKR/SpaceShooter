using UnityEngine;
using Scripts.LevelGeneration;

namespace Scripts.General
{
    public class CompositionRoot : MonoBehaviour
    {
        #region Data
        [SerializeField] private LevelGenerationDataBase levelGenerationData;
        #endregion

        private LevelGenerationControllerBase levelGenerationController;

        private void Awake()
        {
            InitLevelGeneration();
        }

        private void InitLevelGeneration()
        {
            levelGenerationController = new LevelGenerationController(levelGenerationData);
            levelGenerationController.Init();
        }
    }
}