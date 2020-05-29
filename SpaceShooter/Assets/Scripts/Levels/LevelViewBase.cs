using UnityEngine;
using System.Collections.Generic;
using TMPro;

namespace Scripts.Levels
{
    public abstract class LevelViewBase : MonoBehaviour
    {
        public abstract TextMeshProUGUI WinText { get; }
        public abstract TextMeshProUGUI LoseText { get; }
        public abstract TextMeshProUGUI TimeText { get; }
        public abstract TextMeshProUGUI LivesText { get; }
        public abstract Transform SpawnableHolder { get; }
        public abstract List<Transform> SpawnPos { get; }
    }
}