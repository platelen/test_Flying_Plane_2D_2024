using System.Collections;
using Events;
using UnityEngine;

namespace Shooting
{
    public class Shoot : MonoBehaviour
    {
        [SerializeField] private GameObject _bullet;
        [SerializeField] private Transform _startPosBulelet;
        [SerializeField] private SoShootData _soShootData;


        private Coroutine _shootCoroutine;

        private void Start()
        {
            if (gameObject.CompareTag(nameof(Enemy)))
            {
                StartShootEnemyEvent.OnStartShootEnemy.AddListener(StartShooting);
            }
            else
            {
                _shootCoroutine = StartCoroutine(ShootBullet());
            }
        }

        private void StartShooting()
        {
            if (_shootCoroutine == null)
            {
                _shootCoroutine = StartCoroutine(ShootBullet());
            }
        }

        private IEnumerator ShootBullet()
        {
            while (true)
            {
                Instantiate(_bullet, _startPosBulelet.position, _startPosBulelet.rotation);
                yield return new WaitForSeconds(_soShootData.IntervalShoot);
            }
        }
    }
}