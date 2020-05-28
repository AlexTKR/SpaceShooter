using UnityEngine;

namespace Scripts.Player
{
    [CreateAssetMenu(menuName ="Player/Data", fileName ="PlayerData")]
    public class PlayerData : PlayerDataBase
    {
        [SerializeField] private float playerSpeed;

        public override float PlayerSpeed => playerSpeed;
    }
}