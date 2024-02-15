using UnityEngine;

namespace Player
{
    [CreateAssetMenu(menuName = "Create Player Data",fileName = "Player Data")]
    public class SoPlayerData:ScriptableObject
    {
        [SerializeField] private float _moveSpeed = 5f;
        [SerializeField] private int _health = 20;

        public float MoveSpeed => _moveSpeed;

        public int Health
        {
            get => _health;
            set => _health = value;
        }
    }
}
