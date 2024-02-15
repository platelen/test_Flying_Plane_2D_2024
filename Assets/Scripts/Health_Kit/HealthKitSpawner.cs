using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

namespace Health_Kit
{
    public class HealthKitSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _bigHealthKits;
        [SerializeField] private GameObject _smallHealthKits;
        [FormerlySerializedAs("_soHealthKitData")] [SerializeField] private SoHealthKitDataSpawn soHealthKitDataSpawn;
        [SerializeField] private Rect _spawnArea;
        [SerializeField] private Color debugColor = Color.green;


        private void Start()
        {
            StartCoroutine(SpawnPrefabCoroutine(_smallHealthKits,
                Random.Range(soHealthKitDataSpawn.MinSpawnIntervalSmall, soHealthKitDataSpawn.MaxSpawnIntervalSmall)));
            StartCoroutine(SpawnPrefabCoroutine(_bigHealthKits,
                Random.Range(soHealthKitDataSpawn.MinSpawnIntervalBig, soHealthKitDataSpawn.MaxSpawnIntervalBig)));
        }

        private IEnumerator SpawnPrefabCoroutine(GameObject prefab, float spawnInterval)
        {
            yield return new WaitForSeconds(spawnInterval);
            while (true)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(_spawnArea.xMin, _spawnArea.xMax),
                    Random.Range(_spawnArea.yMin, _spawnArea.yMax), 0);
                Instantiate(prefab, spawnPosition, Quaternion.identity);

                yield return new WaitForSeconds(spawnInterval);
            }
        }

        private void OnDrawGizmos()
        {
            DrawSpawnArea();
        }

        private void DrawSpawnArea()
        {
            Gizmos.color = debugColor;

            Vector3 bottomLeft = new Vector3(_spawnArea.xMin, _spawnArea.yMin, 0);
            Vector3 topLeft = new Vector3(_spawnArea.xMin, _spawnArea.yMax, 0);
            Vector3 topRight = new Vector3(_spawnArea.xMax, _spawnArea.yMax, 0);
            Vector3 bottomRight = new Vector3(_spawnArea.xMax, _spawnArea.yMin, 0);

            Gizmos.DrawLine(bottomLeft, topLeft);
            Gizmos.DrawLine(topLeft, topRight);
            Gizmos.DrawLine(topRight, bottomRight);
            Gizmos.DrawLine(bottomRight, bottomLeft);
        }
    }
}