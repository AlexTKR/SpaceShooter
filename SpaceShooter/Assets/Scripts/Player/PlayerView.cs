using System;
using UnityEngine;

namespace Scripts.Player
{
    public class PlayerView : PlayerViewBase
    {
        [SerializeField] private Transform shootPos;
        [SerializeField] private Rigidbody2D playerRigidBody;

        public override Rigidbody2D PlayerRigidBody => playerRigidBody;
        public override Transform ShootPos => shootPos;

        private Action onPlayerColl;

        public override void Subscribe(Action action)
        {
            onPlayerColl += action;
        }

        public override void Unsubscribe(Action action)
        {
            onPlayerColl -= action;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Asteroid")
            {
                onPlayerColl?.Invoke();
            }
        }
    }
}