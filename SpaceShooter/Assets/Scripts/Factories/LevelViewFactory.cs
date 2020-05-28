using UnityEngine;
using Scripts.Levels;

namespace Scripts.Factories
{
    public class LevelViewFactory : SimpleFactory<LevelViewBase>
    {
        [SerializeField] private LevelViewBase levelViewPrefab;

        public override LevelViewBase GetItem()
        {
            LevelViewBase levelView = Instantiate(levelViewPrefab);
            levelView.gameObject.SetActive(false);
            return levelView;
        }
    }
}