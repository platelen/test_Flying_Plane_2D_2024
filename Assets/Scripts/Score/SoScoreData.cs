using UnityEngine;

namespace Score
{
    [CreateAssetMenu(menuName = "Create Score Data",fileName = "Score Data")]
    public class SoScoreData:ScriptableObject
    {
        [SerializeField] private int _scoreValue = 10;

        public int ScoreValue => _scoreValue;
    }
}