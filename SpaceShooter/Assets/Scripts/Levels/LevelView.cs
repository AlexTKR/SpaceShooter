using UnityEngine;
using System.Collections.Generic;
using TMPro;

namespace Scripts.Levels
{
    public class LevelView : LevelViewBase
    {
        [SerializeField] private TextMeshProUGUI timeText;
        [SerializeField] private TextMeshProUGUI livesText;
        [SerializeField] private TextMeshProUGUI winText;
        [SerializeField] private TextMeshProUGUI loseText;
        [SerializeField] private Transform spawnableHolder;
        [SerializeField] private List<Transform> spawnPos;

        public override List<Transform> SpawnPos => spawnPos;
        public override Transform SpawnableHolder => spawnableHolder;
        public override TextMeshProUGUI TimeText => timeText;
        public override TextMeshProUGUI WinText => winText;
        public override TextMeshProUGUI LoseText => loseText;
        public override TextMeshProUGUI LivesText => livesText;
    }
}