using Scripts.Factories;
using Scripts.Spawnable;

namespace Scripts.Player
{
    public class PlayerController : PlayerControllerBase
    {
        private PlayerViewBase playerView;
        private PlayerDataBase playerData;
        private SimpleFactory<SpawnableBase> lazerFactory;

        private IInputReader inputReader;
        private IMovement playerMovement;
        private PlayerShootingBase playerShooting;

        private bool canRead = false;

        public PlayerController(PlayerViewBase _playerView, PlayerDataBase _playerData, SimpleFactory<SpawnableBase> _lazerFactory)
        {
            playerView = _playerView;
            playerData = _playerData;
            lazerFactory = _lazerFactory;
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
            playerData.PlayerLifes = 3;
        }

        public override void Enable()
        {
            canRead = true;
            playerView.transform.position = playerData.StartPos;
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
            playerData.PlayerLifes--;
        }
    }
}