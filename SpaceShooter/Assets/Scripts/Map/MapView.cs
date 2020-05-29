using UnityEngine;

namespace Scripts.Map
{
    public class MapView : MapViewBase
    {
        [SerializeField] private RectTransform levelViewHolder;

        public override RectTransform LevelViewHolder => levelViewHolder;
    }
}