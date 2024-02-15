using Screen_Border;
using Swipe_Controller;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private SoPlayerData _soPlayerData;
        [SerializeField] private SoBorderData _soBorderData;

        private Rigidbody2D _rb;
        private SwipeControlls _swipeControlls;
        private ScreenBorder _screenBorder;

        public SoPlayerData PlayerData
        {
            get => _soPlayerData;
            set => _soPlayerData = value;
        }

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
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
            PlayerData.Health -= damage;
            if (PlayerData.Health <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            Destroy(gameObject);
        }
    }
}