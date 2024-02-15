using UnityEngine;

namespace Bullets
{
    [CreateAssetMenu(menuName = "Create Bullet Data", fileName = "Bullet Data")]
    public class SoBulletData : ScriptableObject
    {
        [SerializeField] private int _bulletDamage = 1;
        [SerializeField] private float _bulletSpeed = 2f;

        public int BulletDamage => _bulletDamage;

        public float BulletSpeed => _bulletSpeed;
    }
}