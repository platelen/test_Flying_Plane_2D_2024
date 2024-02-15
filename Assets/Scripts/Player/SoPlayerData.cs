using UnityEngine;

namespace Player
{
    [CreateAssetMenu(menuName = "Create Player Data",fileName = "Player Data")]
    public class SoPlayerData:ScriptableObject
    {
        [SerializeField] private float _moveSpeed = 5f;

        public float MoveSpeed => _moveSpeed;
    }
}
