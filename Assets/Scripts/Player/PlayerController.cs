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

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _swipeControlls = new SwipeControlls();
            _screenBorder = new ScreenBorder();
        }

        private void Update()
        {
            _swipeControlls.HandleInput(_soPlayerData.MoveSpeed, _rb);
            _screenBorder.CheckBorder(gameObject.transform, _soBorderData.BorderX, _soBorderData.BorderY);
        }
    }
}