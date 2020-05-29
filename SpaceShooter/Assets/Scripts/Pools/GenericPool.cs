using UnityEngine;
using System.Collections.Generic;

namespace Scripts.Pools
{
    public abstract class GenericPool<T> where T : Component
    {
        private Queue<T> objects;

        public void InitiatePool()
        {
            objects = new Queue<T>();
        }

        public int GetCount()
        {
            return objects.Count;
        }

        public bool IsPoolEmpty()
        {
            return objects.Count == 0 ? true : false;
        }

        public T GetInctance()
        {
            if (objects.Count != 0)
            {
                return objects.Dequeue();
            }
            else
            {
                return null;
            }
        }

        public void SetInstance(T instance)
        {
            if (!objects.Contains(instance))
            {
                objects.Enqueue(instance);
            }
        }
    }
}