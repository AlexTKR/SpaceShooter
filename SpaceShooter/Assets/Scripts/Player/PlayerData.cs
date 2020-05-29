using UnityEngine;

namespace Scripts.Player
{
    [CreateAssetMenu(menuName ="Player/Data", fileName ="PlayerData")]
    public class PlayerData : PlayerDataBase
    {
        [SerializeField] private int playerLifes;
        [SerializeField] private Vector3 startPos;
        [SerializeField] private float playerSpeed;

        private int playerLifesTemp;

        public override float PlayerSpeed => playerSpeed;
        public override Vector3 StartPos => startPos;
        public override int PlayerLives { get => playerLifesTemp; set => playerLifesTemp = value; }

        private void OnEnable()
        {
            playerLifesTemp = playerLifes;
        }
    }
}