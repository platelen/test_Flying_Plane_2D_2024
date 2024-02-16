using System;
using System.Collections;
using Events;
using Score;
using Screen_Border;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemy
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private SoEnemyData _soEnemyData;
        [SerializeField] private SoBorderData _soBorderData;
        [SerializeField] private SoScoreData _valueScoreEnemy;


        private ScreenBorder _screenBorder;
        private Rigidbody2D _rigidbody;
        private bool initialMovementComplete = false;

        public static event Action<int> OnEnemyDie;

        private void Start()
        {
            _screenBorder = new ScreenBorder();
            _rigidbody = GetComponent<Rigidbody2D>();
            _soEnemyData.CurrentHealth = _soEnemyData.HealthEnemy;

            StartCoroutine(nameof(InitialMovementCoroutine));
        }

        private void Update()
        {
            _screenBorder.CheckBorder(gameObject.transform, _soBorderData.BorderX, _soBorderData.BorderY);
        }

        private IEnumerator MoveEnemyCoroutine()
        {
            while (true)
            {
                float randomDirection = Random.Range(_soEnemyData.LeftDir, _soEnemyData.RightDir);
                Vector2 movement = (randomDirection < 0.5f) ? Vector2.left : Vector2.right;
                _rigidbody.velocity = movement * _soEnemyData.SpeedEnemy;

                yield return new WaitForSeconds(Random.Range(_soEnemyData.MinValueCorut, _soEnemyData.MaxValueCorut));
            }
        }

        private IEnumerator InitialMovementCoroutine()
        {
            Vector2 startPosition = transform.position;
            Vector2 endPosition = new Vector2(startPosition.x, startPosition.y - _soEnemyData.InitialDistance);
            float flySpeed = _soEnemyData.SpeedEnemy;

            while (transform.position.y > endPosition.y)
            {
                _rigidbody.velocity = Vector2.down * flySpeed;

                yield return null;
            }

            _rigidbody.velocity = Vector2.zero;
            
            StartShootEnemyEvent.SendStartShootEnemy();
            StartCoroutine(MoveEnemyCoroutine());
        }

        public void TakeDamage(int damage)
        {
            _soEnemyData.CurrentHealth -= damage;
            if (_soEnemyData.CurrentHealth <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            int scoreValue = _valueScoreEnemy.ScoreValue;
       
            OnEnemyDie?.Invoke(scoreValue);
            Destroy(gameObject);
        }
    }
}