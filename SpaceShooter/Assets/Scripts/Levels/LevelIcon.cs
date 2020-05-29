using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Scripts.Levels
{
    public class LevelIcon : LevelIconBase
    {
        [SerializeField] private Button levelButton;
        [SerializeField] private TextMeshProUGUI levelNameText;
        [SerializeField] private TextMeshProUGUI levelStatusText;

        public override Button LevelButton => levelButton;
        public override TextMeshProUGUI LevelNameText => levelNameText;
        public override TextMeshProUGUI LevelStatusText => levelStatusText;
    }
}
