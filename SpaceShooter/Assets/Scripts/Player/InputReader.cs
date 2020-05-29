using UnityEngine;

namespace Scripts.Player
{
    public class InputReader : IInputReader
    {
        private IMovement playerMovement;
        private PlayerShootingBase playerShooting;

        private Vector3 moveDirection;

        public InputReader(IMovement _playerMovement, PlayerShootingBase _playerShooting)
        {
            playerMovement = _playerMovement;
            playerShooting = _playerShooting;
        }

        public void Read()
        {
            ReadInput();
        }

        private void ReadInput()
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            moveDirection = new Vector3(moveHorizontal, moveVertical, 0);

            playerMovement.Move(moveDirection);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerShooting.Shoot();
            }
        }
    }
}