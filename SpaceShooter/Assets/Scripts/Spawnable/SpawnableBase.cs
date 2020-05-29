using UnityEngine;
using Scripts.Pools;

namespace Scripts.Spawnable
{
    public abstract class SpawnableBase : MonoBehaviour
    {
        public abstract void SetPool(GenericPool<SpawnableBase> _pool);
    }
}