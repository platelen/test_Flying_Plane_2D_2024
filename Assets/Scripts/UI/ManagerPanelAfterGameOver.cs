using Events;
using UnityEngine;

namespace UI
{
    public class ManagerPanelAfterGameOver : MonoBehaviour
    {
        [SerializeField] private GameObject[] _panelsAfterGamveOver;
        [SerializeField] private GameObject _oldBackground;
        [SerializeField] private GameObject _bestBackground;

        private void OnEnable()
        {
            GameOverEvent.OnStartGameOver.AddListener(EnabledPanels);
            RestartGameEvent.OnStartRestartGame.AddListener(DisablePanels);
            SetBackgroundBestScoreEvent.OnStartSetBackBestScore.AddListener(EnableBestBackground);
        }

        private void OnDisable()
        {
            GameOverEvent.OnStartGameOver.RemoveListener(EnabledPanels);
            RestartGameEvent.OnStartRestartGame.RemoveListener(DisablePanels);
            SetBackgroundBestScoreEvent.OnStartSetBackBestScore.RemoveListener(EnableBestBackground);
        }

        private void EnableBestBackground()
        {
            _oldBackground.SetActive(false);
            _bestBackground.SetActive(true);
        }

        private void EnabledPanels()
        {
            foreach (var panels in _panelsAfterGamveOver)
            {
                panels.SetActive(true);
            }
        }

        private void DisablePanels()
        {
            _oldBackground.SetActive(true);
            _bestBackground.SetActive(false);

            foreach (var panels in _panelsAfterGamveOver)
            {
                panels.SetActive(false);
            }
        }
    }
}