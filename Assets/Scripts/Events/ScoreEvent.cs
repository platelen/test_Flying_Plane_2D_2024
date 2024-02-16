using UnityEngine;
using UnityEngine.Events;

namespace Events
{
    public class ScoreEvent : MonoBehaviour
    {
        public static readonly UnityEvent<int> OnStartAddScore = new UnityEvent<int>();

        public static void SendStartAddScore(int valueScore)
        {
            OnStartAddScore.Invoke(valueScore);
        }
    }
}