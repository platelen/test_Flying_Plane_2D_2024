using Events;
using UnityEngine;

namespace StopGame
{
    public class GameManager : MonoBehaviour
    {
        private void Awake()
        {
            GameOverEvent.OnStartGameOver.AddListener(StopGame);
        }

        private void StopGame()
        {
            StopAllCoroutines();
            Time.timeScale = 0f;
            DestroyAllEnemiesAndBullets();
        }

        private void DestroyAllEnemiesAndBullets()
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
            {
                Destroy(enemy);
            }

            GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
            foreach (GameObject bullet in bullets)
            {
                Destroy(bullet);
            }
        }
    }
}