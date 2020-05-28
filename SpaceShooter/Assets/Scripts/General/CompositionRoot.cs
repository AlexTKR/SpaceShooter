﻿using UnityEngine;
using Scripts.LevelGeneration;
using Scripts.Levels;
using Scripts.Factories;
using Scripts.Map;
using Scripts.Player;

namespace Scripts.General
{
    public class CompositionRoot : MonoBehaviour
    {
        #region view
        [SerializeField] private LevelViewFactory levelViewFactory;
        [SerializeField] private MapViewBase mapView;
        [SerializeField] private PlayerViewBase playerView;
        #endregion
        #region Data
        [SerializeField] private LevelGenerationDataBase levelGenerationData;
        #endregion

        private LevelGenerationControllerBase levelGenerationController;
        private LevelControllerBase levelController;
        private PlayerControllerBase playerController;

        private LevelHolderBase levelHolder;

        private void Awake()
        {
            InitPlayerController();
            InitLevelHolder();
            InitLevelController();
            InitLevelGeneration();
            Init();
        }

        private void Update()
        {
            levelController?.Tick();
            playerController?.Tick();
        }

        private void InitLevelHolder()
        {
            levelHolder = new LevelHolder();
        }

        private void InitLevelGeneration()
        {
            levelGenerationController = new LevelGenerationController(levelController , levelGenerationData, levelHolder, levelViewFactory, mapView);
        }

        private void InitLevelController()
        {
            levelController = new LevelController(levelHolder, this);
        }

        private void InitPlayerController()
        {
            playerController = new PlayerController(playerView);
        }

        private void Init()
        {
            playerController.Init();
            levelGenerationController.Init();
            levelController.Init();
        }
    }
}