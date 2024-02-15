using UnityEngine;

namespace Enemy
{
    [CreateAssetMenu(menuName = "Create Enemy Data", fileName = "Enemy Data")]
    public class SoEnemyData : ScriptableObject
    {
        [SerializeField] private float _speedEnemy = 3f;
        [SerializeField] private int _healthEnemy = 10;
        [SerializeField] private int _currentHealth;

        public float SpeedEnemy => _speedEnemy;

        public int HealthEnemy
        {
            get => _healthEnemy;
            set => _healthEnemy = value;
        }

        public int CurrentHealth
        {
            get => _currentHealth;
            set => _currentHealth = value;
        }
    }
}