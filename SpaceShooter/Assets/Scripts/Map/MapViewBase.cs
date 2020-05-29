using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Map
{
    public abstract class MapViewBase : MonoBehaviour
    {
        public abstract RectTransform LevelViewHolder { get; }
    }
}