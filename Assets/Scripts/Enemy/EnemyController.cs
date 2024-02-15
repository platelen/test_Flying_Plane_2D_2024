using UnityEngine;

namespace Enemy
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private SoEnemyData _soEnemyData;

        public SoEnemyData EnemyData => _soEnemyData;

        private void Start()
        {
            _soEnemyData.CurrentHealth = _soEnemyData.HealthEnemy;
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