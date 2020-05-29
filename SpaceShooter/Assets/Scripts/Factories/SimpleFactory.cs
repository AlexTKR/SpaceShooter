using UnityEngine;

namespace Scripts.Factories
{
    public abstract class SimpleFactory<T> : MonoBehaviour where T : MonoBehaviour
    {
        public abstract T GetItem();
    }
}