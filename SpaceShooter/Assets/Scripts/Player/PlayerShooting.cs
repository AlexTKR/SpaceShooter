using Scripts.Factories;
using Scripts.Spawnable;
using Scripts.Pools;

namespace Scripts.Player
{
    public class PlayerShooting : PlayerShootingBase
    {
        private SimpleFactory<SpawnableBase> lazerFactory;
        private GenericPool<SpawnableBase> lazerPool;
        private PlayerViewBase playerView;

        public PlayerShooting(SimpleFactory<SpawnableBase> _lazerFactory, PlayerViewBase _playerView)
        {
            lazerFactory = _lazerFactory;
            playerView = _playerView;
        }

        public override void Init()
        {
            InitPool();
        }

        public override void Shoot()
        {
            ShootLazers();
        }

        private void ShootLazers()
        {
            if (lazerPool.IsPoolEmpty())
            {
                PopulatePool();
            }

            SpawnableBase Lazer = lazerPool.GetInctance();
            Lazer.transform.position = playerView.ShootPos.position;
            Lazer.gameObject.SetActive(true);
        }

        private void InitPool()
        {
            lazerPool = new LazerPool();
            lazerPool.InitiatePool();
        }

        private void PopulatePool()
        {
            SpawnableBase newLazer = lazerFactory.GetItem();
            newLazer.SetPool(lazerPool);
            newLazer.transform.SetParent(playerView.ShootPos);
            newLazer.gameObject.SetActive(false);
            lazerPool.SetInstance(newLazer);
        }
    }
}