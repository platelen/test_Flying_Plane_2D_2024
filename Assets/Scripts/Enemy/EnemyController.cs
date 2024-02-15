using UnityEngine;

namespace Enemy
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private SoEnemyData _soEnemyData;

        public SoEnemyData EnemyData
        {
            get => _soEnemyData;
            set => _soEnemyData = value;
        }

        public void TakeDamage(int damage)
        {
            EnemyData.HealthEnemy -= damage;
            if (EnemyData.HealthEnemy <= 0)
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