using UnityEngine;

namespace Shooting
{
    [CreateAssetMenu(menuName = "Create Shoot Data",fileName = "Shoot Data")]
    public class SoShootData : ScriptableObject
    {
        [SerializeField] private float _intervalShoot = 1f;

        public float IntervalShoot => _intervalShoot;
    }
}
