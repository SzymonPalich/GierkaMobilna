using UnityEngine;

namespace Assets.Scripts
{
    public class EnemyBullet : MonoBehaviour
    {
        private Rigidbody2D bulletRB;
        public float Force = 12.0f;
        void Start()
        {
            bulletRB = GetComponent<Rigidbody2D>();
            bulletRB.AddRelativeForce(new Vector2(0.0f, Force));
        }

        void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Player"))
            {
                Destroy(gameObject);
            }
        }
    }
}