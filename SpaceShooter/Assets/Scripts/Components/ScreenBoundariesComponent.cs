using UnityEngine;

namespace Scripts.Components
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class ScreenBoundariesComponent : MonoBehaviour
    {
        private Camera camera;
        private SpriteRenderer renderer;
        private Vector2 screenBounds;
        private Vector3 viewPos;
        private float objectWidth;
        private float objectHeight;

        private void Start()
        {
            camera = Camera.main;
            renderer = GetComponent<SpriteRenderer>();
            screenBounds = camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, camera.transform.position.z));
            objectWidth = renderer.bounds.size.x / 2;
            objectHeight = renderer.size.y / 2;
        }

        private void LateUpdate()
        {
            viewPos = transform.position;
            viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x + objectWidth, screenBounds.x * -1 - objectWidth);
            viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y + objectHeight, screenBounds.y * -1 - objectHeight);
            transform.position = viewPos;
        }
    }
}