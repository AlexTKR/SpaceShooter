using UnityEngine;
using Scripts.Levels;

namespace Scripts.Factories
{
    public class LevelIconFactory : SimpleFactory<LevelIconBase>
    {
        [SerializeField] private LevelIconBase levelIconPrefab;

        public override LevelIconBase GetItem()
        {
            LevelIconBase levelView = Instantiate(levelIconPrefab);
            levelView.gameObject.SetActive(false);
            return levelView;
        }
    }
}