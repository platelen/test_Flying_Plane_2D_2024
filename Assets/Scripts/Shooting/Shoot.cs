using System.Collections;
using UnityEngine;

namespace Shooting
{
    public class Shoot : MonoBehaviour
    {
        [SerializeField] private GameObject _bullet;
        [SerializeField] private Transform _startPosBulelet;
        [SerializeField] private SoShootData _soShootData;

        //TODO сделать отключение корутины по событию проигрыша.

        private void Start()
        {
            StartCoroutine(ShootBullet());
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