using UnityEngine;

namespace Health_Kit
{
    [CreateAssetMenu(menuName = "Create Kit Data",fileName = "Kit Data")]
    public class SoKitData:ScriptableObject
    {
        [SerializeField] private float _speedKit = 2f;
        [SerializeField] private int _healthRecovery = 1;
        [SerializeField] private bool _isLargeKit = false;

        public float SpeedKit => _speedKit;

        public int HealthRecovery => _healthRecovery;

        public bool IsLargeKit => _isLargeKit;
    }
}