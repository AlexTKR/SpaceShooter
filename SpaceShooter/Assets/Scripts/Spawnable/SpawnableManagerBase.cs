namespace Scripts.Spawnable
{
    public abstract class SpawnableManagerBase
    {
        public abstract void Init();
        public abstract void SetSpawnable(SpawnableBase spawnable);
        public abstract void Disable();
    }
}