using Enemy;
using TMPro;
using UnityEngine;

namespace UI
{
    public class ScoreHandler : MonoBehaviour
    {
        private TextMeshProUGUI _textScore;

        private void OnEnable()
        {
            EnemyController.OnEnemyDie += SetTextScore;
        }

        private void OnDisable()
        {
            EnemyController.OnEnemyDie -= SetTextScore;
        }

        private void Start()
        {
            _textScore = GetComponent<TextMeshProUGUI>();
        }

        private void SetTextScore(int scoreValue)
        {
            int currentScore = 0;

            if (int.TryParse(_textScore.text, out currentScore))
            {
                int newScore = currentScore + scoreValue;
                _textScore.text = newScore.ToString();
            }
            else
            {
                Debug.LogWarning("Текущий счет не удалось преобразовать в число.");
            }
        }
    }
}