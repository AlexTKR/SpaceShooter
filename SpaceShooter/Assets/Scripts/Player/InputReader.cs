using UnityEngine;

namespace Scripts.Player
{
    public class InputReader : IInputReader
    {
        private IMovement playerMovement;
        private Vector3 moveDirection;

        public InputReader(IMovement _playerMovement)
        {
            playerMovement = _playerMovement;
        }

        public void Read()
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            moveDirection = new Vector3(moveHorizontal, moveVertical, 0 );

            playerMovement.Move(moveDirection);
        }
    }
}