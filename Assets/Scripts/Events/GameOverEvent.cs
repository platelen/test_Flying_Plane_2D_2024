using UnityEngine;
using UnityEngine.Events;

namespace Events
{
    public class GameOverEvent : MonoBehaviour
    {
        public static readonly UnityEvent OnStartGameOver = new UnityEvent();

        public static void SendStartGameOver()
        {
            OnStartGameOver.Invoke();
        }
    }
}