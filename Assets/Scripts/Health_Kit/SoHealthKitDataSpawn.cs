using UnityEngine;

namespace Health_Kit
{
    [CreateAssetMenu(menuName = "Create Health Kit Data Spawn", fileName = "Health Kit Data Spawn")]
    public class SoHealthKitDataSpawn : ScriptableObject
    {
        [SerializeField] private float _minSpawnIntervalBig = 30f;
        [SerializeField] private float _maxSpawnIntervalBig = 60f;
        [SerializeField] private float _minSpawnIntervalSmall = 7f;
        [SerializeField] private float _maxSpawnIntervalSmall = 15f;

        public float MinSpawnIntervalBig => _minSpawnIntervalBig;

        public float MaxSpawnIntervalBig => _maxSpawnIntervalBig;

        public float MinSpawnIntervalSmall => _minSpawnIntervalSmall;

        public float MaxSpawnIntervalSmall => _maxSpawnIntervalSmall;
    }
}