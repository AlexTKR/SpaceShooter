using Scripts.Levels;
using Scripts.Factories;
using Scripts.Map;

namespace Scripts.LevelGeneration
{
    public class LevelGenerationController : LevelGenerationControllerBase
    {
        private LevelGeneratorBase levelGenerator;
        private LevelControllerBase levelController;
        private LevelGenerationDataBase levelGenerationData;
        private LevelHolderBase levelHolder;
        private SimpleFactory<LevelViewBase> levelViewFactory;
        private MapViewBase mapView;

        public LevelGenerationController(LevelControllerBase _levelController,LevelGenerationDataBase _levelGenerationData, LevelHolderBase _levelHolder ,
            SimpleFactory<LevelViewBase> _levelViewFactory, MapViewBase _mapView)
        {
            levelController = _levelController;
            levelGenerationData = _levelGenerationData;
            levelHolder = _levelHolder;
            levelViewFactory = _levelViewFactory;
            mapView = _mapView;
        }

    public override void Init()
    {
        InitLevelGenerator();
    }

    private void InitLevelGenerator()
    {
        levelGenerator = new LevelGenerator(levelController , levelGenerationData, levelHolder, levelViewFactory, mapView);
        levelGenerator.Generate();
    }
}
}