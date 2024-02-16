using Enemy;
using Events;
using TMPro;
using UnityEngine;

namespace UI
{
    public class ScoreHandler : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreCurrentAfterDestroy;
        [SerializeField] private TextMeshProUGUI _textScore;
        [SerializeField] private TextMeshProUGUI _scoreBest;

        private int _bestScore;
        private int _restartText = 0;

        private void OnEnable()
        {
            RestartGameEvent.OnStartRestartGame.AddListener(RestartText);
            EnemyController.OnEnemyDie += SetTextScore;
        }

        private void OnDisable()
        {
            RestartGameEvent.OnStartRestartGame.RemoveListener(RestartText);
            EnemyController.OnEnemyDie -= SetTextScore;
        }

        private void Start()
        {
            _bestScore = GetBestScoreFromStorage();
            _scoreBest.text = _bestScore.ToString();
        }

        private void RestartText()
        {
            _scoreCurrentAfterDestroy.text = _restartText.ToString();
            _textScore.text = _restartText.ToString();
        }

        private void SetTextScore(int scoreValue)
        {
            int currentScore = 0;

            if (int.TryParse(_textScore.text, out currentScore))
            {
                int newScore = currentScore + scoreValue;
                _textScore.text = newScore.ToString();
                _scoreCurrentAfterDestroy.text = newScore.ToString();

                if (newScore > _bestScore)
                {
                    SetBackgroundBestScoreEvent.SendStartSetBackBesScore();
                    _bestScore = newScore;
                    _scoreBest.text = _bestScore.ToString();
                    SaveBestScoreToStorage();
                }
            }
            else
            {
                Debug.LogWarning("Текущий счет не удалось преобразовать в число.");
            }
        }

        public int GetBestScoreFromStorage()
        {
            return PlayerPrefs.GetInt("BestScore", 0);
        }

        private void SaveBestScoreToStorage()
        {
            PlayerPrefs.SetInt("BestScore", _bestScore);
            PlayerPrefs.Save();
        }
    }
}