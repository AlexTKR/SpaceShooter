using UnityEngine;

namespace Scripts.Player
{
    public class PlayerMovement : IMovement
    {
        private PlayerViewBase playerView;
        private PlayerDataBase playerData;        

        public PlayerMovement(PlayerViewBase _playerView, PlayerDataBase _playerData)
        {
            playerView = _playerView;
            playerData = _playerData;
        }

        public void Move(Vector3 direction)
        {
            playerView.PlayerRigidBody.velocity = direction * playerData.PlayerSpeed * Time.fixedDeltaTime;
        }
    }
}