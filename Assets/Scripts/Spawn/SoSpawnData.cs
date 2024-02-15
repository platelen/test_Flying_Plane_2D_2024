using UnityEngine;

namespace Spawn
{
    [CreateAssetMenu(menuName = "Create Spawn Data",fileName = "Spawn Data")]
    public class SoSpawnData:ScriptableObject
    {
        [SerializeField] private float _minSpawnInterval = 1f;
        [SerializeField] private float _maxSpawnInterval = 3f;

        public float MinSpawnInterval => _minSpawnInterval;

        public float MaxSpawnInterval => _maxSpawnInterval;
    }
}