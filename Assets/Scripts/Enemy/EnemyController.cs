using System.Collections;
using Screen_Border;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemy
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private SoEnemyData _soEnemyData;
        [SerializeField] private SoBorderData _soBorderData;


        private ScreenBorder _screenBorder;
        private Rigidbody2D _rigidbody;
        public SoEnemyData EnemyData => _soEnemyData;


        private void Start()
        {
            _screenBorder = new ScreenBorder();
            _rigidbody = GetComponent<Rigidbody2D>();
            EnemyData.CurrentHealth = EnemyData.HealthEnemy;
            
            StartCoroutine(nameof(MoveEnemyCoroutine));
        }

        private void Update()
        {
            _screenBorder.CheckBorder(gameObject.transform, _soBorderData.BorderX, _soBorderData.BorderY);
        }

        private IEnumerator MoveEnemyCoroutine()
        {
            while (true)
            {
                float randomDirection = Random.Range(EnemyData.LeftDir, EnemyData.RightDir);
                Vector2 movement = (randomDirection < 0.5f) ? Vector2.left : Vector2.right;
                _rigidbody.velocity = movement * EnemyData.SpeedEnemy;

                yield return new WaitForSeconds(Random.Range(EnemyData.MinValueCorut, EnemyData.MaxValueCorut));
            }
        }

        public void TakeDamage(int damage)
        {
            EnemyData.CurrentHealth -= damage;
            if (EnemyData.CurrentHealth <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            Destroy(gameObject);
        }
    }
}