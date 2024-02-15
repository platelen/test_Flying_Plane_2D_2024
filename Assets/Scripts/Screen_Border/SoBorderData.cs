using UnityEngine;

namespace Screen_Border
{
    [CreateAssetMenu(menuName = "Create Border Data",fileName = "Border Data")]
    public class SoBorderData:ScriptableObject
    {
        [SerializeField] private float _borderX = 1.5f;
        [SerializeField] private float _borderY = 4f;

        public float BorderX => _borderX;

        public float BorderY => _borderY;
    }
}