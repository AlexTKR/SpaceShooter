using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Scripts.Levels
{
    public abstract class LevelIconBase : MonoBehaviour
    {
        public abstract Button LevelButton { get; }
        public abstract TextMeshProUGUI LevelNameText { get; }
        public abstract TextMeshProUGUI LevelStatusText { get; }
    }
}
