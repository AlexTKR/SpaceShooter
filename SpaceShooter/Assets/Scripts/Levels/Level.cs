namespace Scripts.Levels
{
    public class Level : LevelBase
    {
        private LevelControllerBase levelController;
        private LevelData levelData;
        private LevelIconBase levelIcon;

        public override LevelData LevelData => levelData;
 
        public Level(LevelControllerBase _levelController, LevelData _levelData, LevelIconBase _levelIcon)
        {
            levelController = _levelController;
            levelData = _levelData;
            levelIcon = _levelIcon;
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
            levelIcon.LevelNameText.text = levelData.levelName;
        }

        private void Subscribe()
        {
            levelIcon.LevelButton.onClick.AddListener(StartLevel);
        }

        private void SetLevelStatus()
        {
            switch (levelData.levelStatus)
            {
                case LevelStatus.Closed:
                    levelIcon.LevelStatusText.text = "Closed";
                    levelIcon.LevelButton.interactable = false;
                    break;

                case LevelStatus.Open:
                    levelIcon.LevelStatusText.text = "Open";
                    levelIcon.LevelButton.interactable = true;
                    break;

                case LevelStatus.Completed:
                    levelIcon.LevelStatusText.text = "Complited";
                    levelIcon.LevelButton.interactable = true;
                    break;
            }
        }

        private void StartLevel()
        {
            levelController.StartLevel(this);
        }
    }
}