using System.Collections;
using Player;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Spawn
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private Transform _startPosPlayer;

        [Header("Spawn Enemy")] [SerializeField]
        private GameObject prefabToSpawn;

        [SerializeField] private Transform[] spawnPoints;
        [SerializeField] private SoSpawnData _soSpawnData;


        private PlayerController _playerController;


        private void Start()
        {
            StartCoroutine(nameof(SpawnPrefabWithInterval));
            CreatePlayerInstance(nameof(Player));
        }


        private IEnumerator SpawnPrefabWithInterval()
        {
            while (true)
            {
                Transform spawnPoint = GetRandomSpawnPoint();

                GameObject prefab = Instantiate(prefabToSpawn, spawnPoint.position, spawnPoint.rotation);
                prefab.SetActive(true);

                float spawnInterval = Random.Range(_soSpawnData.MinSpawnInterval, _soSpawnData.MaxSpawnInterval);
                yield return new WaitForSeconds(spawnInterval);
            }
        }

        private Transform GetRandomSpawnPoint()
        {
            int randomIndex = Random.Range(0, spawnPoints.Length);
            return spawnPoints[randomIndex];
        }

        private void CreatePlayerInstance(string prefabName)
        {
            // Поиск префаба по имени в папке Resources/Prefabs
            GameObject playerPrefab = Resources.Load<GameObject>("Prefabs/" + prefabName);

            if (playerPrefab != null)
            {
                GameObject playerObject = Instantiate(playerPrefab, _startPosPlayer.position, Quaternion.identity);

                _playerController = playerObject.GetComponent<PlayerController>();

                if (_playerController != null)
                {
                    // Делам что-то...
                }
                else
                {
                    Debug.LogError("Не удалось получить ссылку на компонент PlayerController в созданном объекте.");
                }
            }
            else
            {
                Debug.LogError("Префаб с именем " + prefabName + " не найден в папке Assets/Prefabs.");
            }
        }
    }
}