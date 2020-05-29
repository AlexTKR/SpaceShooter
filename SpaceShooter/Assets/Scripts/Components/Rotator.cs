using UnityEngine;

namespace Scripts.Components
{
    public class Rotator : MonoBehaviour
    {
        [SerializeField] private float speed;

        private Vector3 direction;

        private void Start()
        {
            direction = new Vector3(0, 0, 1);
        }

        private void Update()
        {
            transform.Rotate(direction * speed * Time.deltaTime);
        }
    }
}