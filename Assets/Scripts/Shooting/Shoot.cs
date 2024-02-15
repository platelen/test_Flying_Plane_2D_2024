using UnityEngine;

namespace Shooting
{
    public class Shoot : MonoBehaviour
    {
        [SerializeField] private GameObject _bullet;
        [SerializeField] private Transform _startPosBulelet;

        private void Update()
        {
            if (Input.GetMouseButtonDown(1))
            {
                Instantiate(_bullet, _startPosBulelet.position, _startPosBulelet.rotation);
            }
        }
    }
}