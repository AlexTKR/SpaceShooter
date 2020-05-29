using UnityEngine;

namespace Scripts.Map
{
    public class MapController : MapControllerBase
    {
        private MapViewBase mapView;
        private MapDataBase mapData; 

        public MapController(MapViewBase _mapView, MapDataBase _mapData)
        {
            mapView = _mapView;
            mapData = _mapData;
        }

        public override void Disable()
        {
            mapView.gameObject.SetActive(false);
        }

        public override void Enable()
        {
            mapView.gameObject.SetActive(true);
        }

        public override void Init()
        {
            InitLevelIcons();
        }

        private void InitLevelIcons()
        {
            int childCount = mapView.LevelViewHolder.childCount;
            float posY = mapView.LevelViewHolder.GetChild(0).position.y; 
            float posX = 0;

            for (int i = 1; i < childCount; i++)
            {
                posY += mapData.MapYoffset; 
                posX = Random.Range(mapView.LevelViewHolder.GetChild(i).position.x, mapView.LevelViewHolder.rect.width - mapData.MapXoffset);
                mapView.LevelViewHolder.GetChild(i).position = new Vector3(posX, posY, mapView.LevelViewHolder.GetChild(i).position.z);
            }
        }
    }
}