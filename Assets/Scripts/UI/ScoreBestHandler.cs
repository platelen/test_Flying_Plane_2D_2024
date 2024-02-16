using TMPro;
using UnityEngine;

namespace UI
{
    public class ScoreBestHandler : MonoBehaviour
    {
        [SerializeField] private ScoreHandler _scoreHandler;
        [SerializeField] private TextMeshProUGUI _scoreCurrent;
        [SerializeField] private TextMeshProUGUI _scoreBest;

        private int _bestScore;

        private void Start()
        {
            _bestScore = GetBestScoreFromStorage();
            _scoreBest.text = _bestScore.ToString();
        }
        
        // public void Scoring(int score)
        // {
        //     score=_scoreHandler.
        //     _scoreCurrent.text = score.ToString();
        //
        //     if (score > _bestScore)
        //     {
        //         _bestScore = score;
        //         _scoreBest.text = _bestScore.ToString();
        //         SaveBestScoreToStorage();
        //     }
        // }
        
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