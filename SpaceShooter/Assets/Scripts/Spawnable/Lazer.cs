using Scripts.Pools;
using UnityEngine;

namespace Scripts.Spawnable
{
    public class Lazer : SpawnableBase
    {
        [SerializeField] private float speed;
        [SerializeField] private Rigidbody2D rigidBody;

        private Vector3 direction;
        private string shredderTag = "Shredder";
        private string asteroidTag = "Asteroid";

        GenericPool<SpawnableBase> pool;

        private void Start()
        {
            direction = new Vector3(0, 1, 0);
        }

        private void FixedUpdate()
        {
            rigidBody.velocity = direction * speed * Time.fixedDeltaTime;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == shredderTag || collision.tag == asteroidTag)
            {
                gameObject.SetActive(false);
                pool.SetInstance(this);
            }
        }

        public override void SetPool(GenericPool<SpawnableBase> _pool)
        {
            pool = _pool;
        }

        public override void Disable()
        {
            
        }
    }
}