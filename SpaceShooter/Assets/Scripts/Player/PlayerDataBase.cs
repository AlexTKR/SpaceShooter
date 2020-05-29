using UnityEngine;

namespace Scripts.Player
{
    public abstract class PlayerDataBase : ScriptableObject
    {
        public abstract int PlayerLifes { get; set; }
        public abstract Vector3 StartPos { get; }
        public abstract float PlayerSpeed { get; }
    }
}