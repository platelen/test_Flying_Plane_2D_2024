using Screen_Border;
using Swipe_Controller;
using UI;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private SoPlayerData _soPlayerData;
        [SerializeField] private SoBorderData _soBorderData;
        [SerializeField] private HealthBar _healthBar;

        private Rigidbody2D _rb;
        private SwipeControlls _swipeControlls;
        private ScreenBorder _screenBorder;

        public SoPlayerData PlayerData => _soPlayerData;


        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _soPlayerData.CurrentHealth = _soPlayerData.Health;

            _healthBar = FindObjectOfType<HealthBar>();

            if (_healthBar == null)
            {
                Debug.LogError("Не удалось найти объект HealthBar на сцене.");
            }
            else
            {
                _healthBar.SetMaxHealth(_soPlayerData.Health);
            }

            _healthBar.SetMaxHealth(_soPlayerData.Health);
            _swipeControlls = new SwipeControlls();
            _screenBorder = new ScreenBorder();
        }

        private void Update()
        {
            _swipeControlls.HandleInput(PlayerData.MoveSpeed, _rb);
            _screenBorder.CheckBorder(gameObject.transform, _soBorderData.BorderX, _soBorderData.BorderY);
        }

        public void TakeDamage(int damage)
        {
            _soPlayerData.CurrentHealth -= damage;
            _healthBar.SetHealth(_soPlayerData.CurrentHealth);

            if (_soPlayerData.CurrentHealth <= 0)
            {
                Die();
            }
        }

        public void HealingPlayer(int heal)
        {
            _soPlayerData.CurrentHealth += heal;
            _healthBar.SetHealth(_soPlayerData.CurrentHealth);
        }

        private void Die()
        {
            Destroy(gameObject);
        }
    }
}