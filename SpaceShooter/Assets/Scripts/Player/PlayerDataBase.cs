using UnityEngine;

namespace Scripts.Player
{
    public abstract class PlayerDataBase : ScriptableObject
    {
        public abstract float PlayerSpeed { get; }
    }
}