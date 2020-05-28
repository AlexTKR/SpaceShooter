namespace Scripts.Player
{
    public class PlayerController : PlayerControllerBase
    {
        private PlayerViewBase playerView;

        private bool canRead = false;

        public PlayerController(PlayerViewBase _playerView)
        {
            playerView = _playerView;
        }

        public override void Init()
        {

        }

        public override void Tick()
        {
            if (canRead)
            {

            }
        }

        public override void Disable()
        {

        }

        public override void Enable()
        {

        }
    }
}