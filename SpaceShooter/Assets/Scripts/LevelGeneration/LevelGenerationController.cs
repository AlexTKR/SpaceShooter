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
        private SimpleFactory<LevelIconBase> levelIconFactory;
        private MapViewBase mapView;

        public LevelGenerationController(LevelControllerBase _levelController,LevelGenerationDataBase _levelGenerationData, LevelHolderBase _levelHolder ,
            SimpleFactory<LevelIconBase> _levelIconFactory, MapViewBase _mapView)
        {
            levelController = _levelController;
            levelGenerationData = _levelGenerationData;
            levelHolder = _levelHolder;
            levelIconFactory = _levelIconFactory;
            mapView = _mapView;
        }

    public override void Init()
    {
        InitLevelGenerator();
    }

    private void InitLevelGenerator()
    {
        levelGenerator = new LevelGenerator(levelController , levelGenerationData, levelHolder, levelIconFactory, mapView);
        levelGenerator.Generate();
    }
}
}