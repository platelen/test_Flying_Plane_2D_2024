using UnityEngine;
using UnityEngine.Events;

namespace Events
{
    public class StartShootEnemyEvent : MonoBehaviour
    {
        public static readonly UnityEvent OnStartShootEnemy = new UnityEvent();

        public static void SendStartShootEnemy()
        {
            OnStartShootEnemy.Invoke();
        }
    }
}