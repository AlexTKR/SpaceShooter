using UnityEngine;
using System;

namespace Scripts.Player
{
    public abstract class PlayerViewBase : MonoBehaviour
    {
        public abstract Transform ShootPos{ get; }
        public abstract Rigidbody2D PlayerRigidBody { get; }

        public abstract void Subscribe(Action action);
        public abstract void Unsubscribe(Action action);
    }
}