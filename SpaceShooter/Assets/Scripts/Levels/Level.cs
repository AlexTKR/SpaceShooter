namespace Scripts.Levels
{
    public class Level : LevelBase
    {
        private LevelControllerBase levelController;
        private LevelData levelData;
        private LevelViewBase levelView;

        public override LevelData LevelData => levelData;
 
        public Level(LevelControllerBase _levelController, LevelData _levelData, LevelViewBase _levelView)
        {
            levelController = _levelController;
            levelData = _levelData;
            levelView = _levelView;
        }

        public override void Init()
        {
            InitLevelView();
            SetLevelStatus();
            Subscribe();
        }


        public override void SetStatus()
        {
            SetLevelStatus();
        }

        private void InitLevelView()
        {
            levelView.LevelNameText.text = levelData.levelName;
        }

        private void Subscribe()
        {
            levelView.LevelButton.onClick.AddListener(StartLevel);
        }

        private void SetLevelStatus()
        {
            switch (levelData.levelStatus)
            {
                case LevelStatus.Closed:
                    levelView.LevelStatusText.text = "Closed";
                    levelView.LevelButton.interactable = false;
                    break;

                case LevelStatus.Open:
                    levelView.LevelStatusText.text = "Open";
                    levelView.LevelButton.interactable = true;
                    break;

                case LevelStatus.Completed:
                    levelView.LevelStatusText.text = "Complited";
                    levelView.LevelButton.interactable = true;
                    break;
            }
        }

        private void StartLevel()
        {

        }
    }
}