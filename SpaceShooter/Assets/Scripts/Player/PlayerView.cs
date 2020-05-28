using UnityEngine;

namespace Scripts.Player
{
    public class PlayerView : PlayerViewBase
    {
        [SerializeField] private Rigidbody2D playerRigidBody;

        public override Rigidbody2D PlayerRigidBody => playerRigidBody;
    }
}