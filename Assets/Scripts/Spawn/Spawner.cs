using Player;
using UnityEngine;

namespace Spawn
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private Transform _startPosPlayer;

        private PlayerController _playerController;

        private void Start()
        {
            CreatePlayerInstance(nameof(Player));
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