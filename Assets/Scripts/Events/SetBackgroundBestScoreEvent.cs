using UnityEngine.Events;

namespace Events
{
    public class SetBackgroundBestScoreEvent
    {
        public static readonly UnityEvent OnStartSetBackBestScore = new UnityEvent();

        public static void SendStartSetBackBesScore()
        {
            OnStartSetBackBestScore.Invoke();
        }
    }
}