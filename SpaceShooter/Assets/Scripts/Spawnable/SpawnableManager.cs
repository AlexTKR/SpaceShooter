using System.Collections.Generic;

namespace Scripts.Spawnable
{
    public class SpawnableManager : SpawnableManagerBase
    {
        private List<SpawnableBase> activeSpawnableHolder;

        public SpawnableManager()
        {

        }

        public override void Disable()
        {
            DisableAvtiveSpawnables();
        }

        public override void Init()
        {
            InitHolder();
        }

        public override void SetSpawnable(SpawnableBase spawnable)
        {
            activeSpawnableHolder.Add(spawnable);
        }

        private void InitHolder()
        {
            activeSpawnableHolder = new List<SpawnableBase>();
        }

        private void DisableAvtiveSpawnables()
        {
            for (int i = 0; i < activeSpawnableHolder.Count; i++)
            {
                if (activeSpawnableHolder[i].gameObject.activeSelf == true)
                {
                    activeSpawnableHolder[i].Disable();
                }
            }

            activeSpawnableHolder.Clear();
        }
    }
}