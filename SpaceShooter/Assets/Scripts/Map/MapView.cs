using UnityEngine;

namespace Scripts.Map
{
    public class MapView : MapViewBase
    {
        [SerializeField] private Transform levelViewHolder;

        public override Transform LevelViewHolder => levelViewHolder;
    }
}