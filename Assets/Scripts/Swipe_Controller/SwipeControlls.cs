using UnityEngine;

namespace Swipe_Controller
{
    public class SwipeControlls
    {
        private Vector2 touchStartPos;
        private bool isDragging = false;


        public void HandleInput(float _soMoveSpeed, Rigidbody2D rb)
        {
            if (Input.GetMouseButtonDown(1))
                Debug.Log("Нажата правая кнопка мышки");
            
            if (Input.GetMouseButtonDown(0))
            {
                touchStartPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                isDragging = true;
            }

            if (Input.GetMouseButton(0) && isDragging)
            {
                Vector2 direction = (Vector2) Camera.main.ScreenToWorldPoint(Input.mousePosition) - touchStartPos;
                rb.velocity = new Vector2(direction.x, 0) * _soMoveSpeed;
            }

            if (Input.GetMouseButtonUp(0))
            {
                isDragging = false;
                rb.velocity = Vector2.zero;
            }

            foreach (Touch touch in Input.touches)
            {
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        touchStartPos = Camera.main.ScreenToWorldPoint(touch.position);
                        isDragging = true;
                        break;
                    case TouchPhase.Moved:
                        if (isDragging)
                        {
                            Vector2 direction = (Vector2) Camera.main.ScreenToWorldPoint(touch.position) -
                                                touchStartPos;
                            rb.velocity = new Vector2(direction.x, 0) * _soMoveSpeed;
                        }

                        break;
                    case TouchPhase.Ended:
                        isDragging = false;
                        rb.velocity = Vector2.zero;
                        break;
                }
            }
        }
    }
}