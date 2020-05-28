using UnityEngine;

namespace Scripts.Map
{
    public abstract class MapViewBase : MonoBehaviour
    {
        public abstract Transform LevelViewHolder { get; }
    }
}