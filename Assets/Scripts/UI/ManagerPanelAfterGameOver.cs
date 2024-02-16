using System;
using Events;
using UnityEngine;

namespace UI
{
    public class ManagerPanelAfterGameOver : MonoBehaviour
    {
        [SerializeField] private GameObject[] _panelsAfterGamveOver;

        private void OnEnable()
        {
            GameOverEvent.OnStartGameOver.AddListener(EnabledPanels);
            RestartGameEvent.OnStartRestartGame.AddListener(DisablePanels);
        }

        private void OnDisable()
        {
            GameOverEvent.OnStartGameOver.RemoveListener(EnabledPanels);
            RestartGameEvent.OnStartRestartGame.RemoveListener(DisablePanels);
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
            foreach (var panels in _panelsAfterGamveOver)
            {
                panels.SetActive(false);
            }
        }
    }
}