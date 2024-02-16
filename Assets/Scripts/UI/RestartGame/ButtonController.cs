using Events;
using UnityEngine;
using UnityEngine.UI;

namespace UI.RestartGame
{
    public class ButtonController : MonoBehaviour
    {
        private Button _button;

        private void Start()
        {
            _button = GetComponent<Button>();
        }

        public void RestartGame()
        {
            RestartGameEvent.SendStartRestartGame();
        }

        public void ExitGame()
        {
            Debug.Log("Exit");
            Application.Quit();
        }
    }
}