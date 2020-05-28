using UnityEngine;
using Scripts.LevelGeneration;
using Scripts.Levels;

namespace Scripts.General
{
    public class CompositionRoot : MonoBehaviour
    {
        #region view

        #endregion

        #region Data
        [SerializeField] private LevelGenerationDataBase levelGenerationData;
        #endregion

        private LevelGenerationControllerBase levelGenerationController;
        private LevelControllerBase levelController;

        private LevelHolderBase levelHolder;

        private void Awake()
        {
            InitLevelHolder();
            InitLevelGeneration();
            InitLevelController();
        }

        private void Update()
        {
            levelController?.Tick();
        }

        private void InitLevelHolder()
        {
            levelHolder = new LevelHolder();
        }

        private void InitLevelGeneration()
        {
            levelGenerationController = new LevelGenerationController(levelGenerationData, levelHolder);
            levelGenerationController.Init();
        }

        private void InitLevelController()
        {
            levelController = new LevelController(levelHolder);
            levelController.Init();
        }
    }
}