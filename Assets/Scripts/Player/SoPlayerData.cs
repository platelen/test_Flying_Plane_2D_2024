using UnityEngine;

namespace Player
{
    [CreateAssetMenu(menuName = "Create Player Data", fileName = "Player Data")]
    public class SoPlayerData : ScriptableObject
    {
        [SerializeField] private float _moveSpeed = 5f;
        [SerializeField] private int _health = 20;
        [SerializeField] private int _currentHealth;

        public float MoveSpeed => _moveSpeed;
        public int Health => _health;

        public int CurrentHealth
        {
            get => _currentHealth;
            set => _currentHealth = value;
        }
    }
}