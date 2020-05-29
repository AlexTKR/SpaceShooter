using UnityEngine;

namespace Scripts.Map
{
    [CreateAssetMenu(menuName ="Map/Data", fileName ="MapData")]
    public class MapData : MapDataBase
    {
        [SerializeField] private float mapXoffset;
        [SerializeField] private float mapYoffset;

        public override float MapXoffset => mapXoffset;
        public override float MapYoffset => mapYoffset;
    }
}