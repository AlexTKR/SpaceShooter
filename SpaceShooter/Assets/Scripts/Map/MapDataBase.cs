using UnityEngine;

namespace Scripts.Map
{
    public abstract class MapDataBase : ScriptableObject
    {
        public abstract float MapXoffset { get; }
        public abstract float MapYoffset { get; }
    }
}