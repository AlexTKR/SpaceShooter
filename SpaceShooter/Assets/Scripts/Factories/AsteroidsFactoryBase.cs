using UnityEngine;
using Scripts.Spawnable;

namespace Scripts.Factories
{
    public abstract class AsteroidsFactoryBase : MonoBehaviour
    {
        public abstract SpawnableBase GetItem(string name);
    }
}