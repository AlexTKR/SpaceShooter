using Scripts.Factories;
using Scripts.Spawnable;
using Scripts.Levels;

namespace Scripts.Player
{
    public class PlayerController : PlayerControllerBase
    {
        private PlayerViewBase playerView;
        private PlayerDataBase playerData;
        private SimpleFactory<SpawnableBase> lazerFactory;
        private LevelViewBase levelView;

        private IInputReader inputReader;
        private IMovement playerMovement;
        private PlayerShootingBase playerShooting;

        private bool canRead = false;

        public PlayerController(PlayerViewBase _playerView, PlayerDataBase _playerData, SimpleFactory<SpawnableBase> _lazerFactory, LevelViewBase _levelView)
        {
            playerView = _playerView;
            playerData = _playerData;
            lazerFactory = _lazerFactory;
            levelView = _levelView;
        }

        public override void Init()
        {
            InitPlayerShooting();
            InitPlayerMovement();
            InitInputReader();           
            Subscribe();
        }

        public override void Tick()
        {
            if (canRead)
            {
                inputReader.Read();
            }
        }

        public override void Disable()
        {
            canRead = false;
            playerData.PlayerLives = 3;
        }

        public override void Enable()
        {
            canRead = true;
            playerView.transform.position = playerData.StartPos;
            levelView.LivesText.text = playerData.PlayerLives.ToString();
        }

        private void InitInputReader()
        {
            inputReader = new InputReader(playerMovement, playerShooting);
        }

        private void InitPlayerMovement()
        {
            playerMovement = new PlayerMovement(playerView, playerData);
        }

        private void InitPlayerShooting()
        {
            playerShooting = new PlayerShooting(lazerFactory, playerView);
            playerShooting.Init();
        }

        private void Subscribe()
        {
            playerView.Subscribe(OnPlayerCollided);
        }

        private void OnPlayerCollided()
        {
            playerData.PlayerLives--;
            levelView.LivesText.text = playerData.PlayerLives.ToString();
        }
    }
}