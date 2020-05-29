using UnityEngine;
using Scripts.Spawnable;

namespace Scripts.Factories
{
    public class LazerFactory : SimpleFactory<SpawnableBase>
    {
        [SerializeField] private SpawnableBase lazer;

        public override SpawnableBase GetItem()
        {
            SpawnableBase newLazer = Instantiate(lazer);
            return newLazer;
        }
    }
}