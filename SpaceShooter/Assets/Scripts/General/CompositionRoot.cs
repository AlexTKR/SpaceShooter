using UnityEngine;
using Scripts.LevelGeneration;
using Scripts.Levels;
using Scripts.Factories;
using Scripts.Map;
using Scripts.Player;
using Scripts.Saving;

namespace Scripts.General
{
    public class CompositionRoot : MonoBehaviour
    {
        [SerializeField] private LevelIconFactory levelIconFactory;
        [SerializeField] private AsteroidsFactoryBase asteroidFactory;
        [SerializeField] private LazerFactory lazerFactory; 
        #region view
        [SerializeField] private MapViewBase mapView;
        [SerializeField] private LevelViewBase levelView;
        [SerializeField] private PlayerViewBase playerView;
        #endregion
        #region Data
        [SerializeField] private LevelGenerationDataBase levelGenerationData;
        [SerializeField] private PlayerDataBase playerData;
        [SerializeField] private MapDataBase mapData;
        #endregion

        private LevelGenerationControllerBase levelGenerationController;
        private LevelControllerBase levelController;
        private PlayerControllerBase playerController;
        private MapControllerBase mapController;

        private LevelHolderBase levelHolder;

        private void Awake()
        {
            InitMapController();
            InitPlayerController();
            InitLevelHolder();
            InitLevelController();
            InitLevelGeneration();
            Init();
        }

        private void FixedUpdate()
        {
            playerController?.Tick();
        }

        private void OnDisable()
        {
            SerializationManager.Save("Save", SaveData.Current);
        }

        private void InitLevelHolder()
        {
            levelHolder = new LevelHolder();
        }

        private void InitMapController()
        {
            mapController = new MapController(mapView, mapData);
        }

        private void InitLevelGeneration()
        {
            levelGenerationController = new LevelGenerationController(levelController, levelGenerationData, levelHolder, levelIconFactory, mapView);
        }

        private void InitLevelController()
        {
            levelController = new LevelController(levelView, levelHolder, this, playerController, playerData, asteroidFactory, mapController);
        }

        private void InitPlayerController()
        {
            playerController = new PlayerController(playerView, playerData, lazerFactory, levelView);
        }

        private void Init()
        {
            playerController.Init();
            levelGenerationController.Init();
            levelController.Init();
            mapController.Init();
        }
    }
}