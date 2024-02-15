using Enemy;
using Player;
using UnityEngine;

namespace Bullets
{
    public class BulletController : MonoBehaviour
    {
        [SerializeField] private SoBulletData _bulletData;

        private Rigidbody2D _rb;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _rb.velocity = transform.up * _bulletData.BulletSpeed;
        }

        private void OnTriggerEnter2D(Collider2D hitInfo)
        {
            if (hitInfo.CompareTag(nameof(Enemy)))
            {
                EnemyController enemy = hitInfo.GetComponent<EnemyController>();
                if (enemy != null)
                    enemy.TakeDamage(_bulletData.BulletDamage);
                Destroy(gameObject);
            }
            else if (hitInfo.CompareTag(nameof(Player)))
            {
                PlayerController player = hitInfo.GetComponent<PlayerController>();
                if (player != null)
                    player.TakeDamage(_bulletData.BulletDamage);
                Destroy(gameObject);
            }
            else if (hitInfo.CompareTag("Border"))
            {
                Destroy(gameObject);
            }
        }
    }
}