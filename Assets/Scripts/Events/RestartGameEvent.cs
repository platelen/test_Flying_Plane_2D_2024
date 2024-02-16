using UnityEngine;
using UnityEngine.Events;

namespace Events
{
    public class RestartGameEvent:MonoBehaviour
    {
        public static readonly UnityEvent OnStartRestartGame = new UnityEvent();

        public static void SendStartRestartGame()
        {
            OnStartRestartGame.Invoke();
        }
    }
}