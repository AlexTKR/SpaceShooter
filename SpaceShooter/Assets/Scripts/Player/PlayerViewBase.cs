using UnityEngine;

namespace Scripts.Player
{
    public abstract class PlayerViewBase : MonoBehaviour
    {
        public abstract Rigidbody2D PlayerRigidBody { get; }
    }
}