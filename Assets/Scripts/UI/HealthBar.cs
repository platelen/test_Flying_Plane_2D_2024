using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Image _fill;

        public Gradient gradient;

        private Slider _slider;


        private void Start()
        {
            _slider = GetComponent<Slider>();
        }

        public void SetMaxHealth(int health)
        {
            _slider.maxValue = health;
            _slider.value = health;

            _fill.color = gradient.Evaluate(1f);
        }

        public void SetHealth(int health)
        {
            _slider.value = health;
            _fill.color = gradient.Evaluate(_slider.normalizedValue);
        }
    }
}