using UnityEngine;

namespace Enemy
{
    [CreateAssetMenu(menuName = "Create Enemy Data", fileName = "Enemy Data")]
    public class SoEnemyData : ScriptableObject
    {
        [SerializeField] private float _speedEnemy = 3f;
        [SerializeField] private int _healthEnemy = 10;
        [SerializeField] private int _currentHealth;
        [Header("Coroutine controller")]
        [SerializeField] private float _minValueCorut = 1f;
        [SerializeField] private float _maxValueCorut = 1.5f;
        [SerializeField] private float _leftDir = 0f;
        [SerializeField] private float _rightDir = 1f;
        [SerializeField] private float _initialDistance = 5f;
        

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

        public float MinValueCorut => _minValueCorut;

        public float MaxValueCorut => _maxValueCorut;

        public float LeftDir => _leftDir;

        public float RightDir => _rightDir;

        public float InitialDistance => _initialDistance;
    }
}