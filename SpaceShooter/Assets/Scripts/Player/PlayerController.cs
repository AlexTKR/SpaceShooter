namespace Scripts.Player
{
    public class PlayerController : PlayerControllerBase
    {
        private PlayerViewBase playerView;
        private PlayerDataBase playerData;
        private IInputReader inputReader;
        private IMovement playerMovement;

        private bool canRead = false;

        public PlayerController(PlayerViewBase _playerView, PlayerDataBase _playerData)
        {
            playerView = _playerView;
            playerData = _playerData;
        }

        public override void Init()
        {
            InitPlayerMovement();
            InitInputReader();
        }

        public override void Tick()
        {
            //if (canRead)
            // {
            inputReader.Read();
            //   }
        }

        public override void Disable()
        {

        }

        public override void Enable()
        {

        }

        private void InitInputReader()
        {
            inputReader = new InputReader(playerMovement);
        }

        private void InitPlayerMovement()
        {
            playerMovement = new PlayerMovement(playerView, playerData);
        }
    }
}