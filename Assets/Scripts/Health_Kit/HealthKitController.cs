﻿using UnityEngine;


namespace Health_Kit
{
    public class HealthKitController : MonoBehaviour
    {
        [SerializeField] private SoKitData _soKitData;

        private Rigidbody2D _rigidbody;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            MoveKit();
        }

        private void MoveKit()
        {
            float newY = transform.position.y - _soKitData.SpeedKit * Time.deltaTime;
            _rigidbody.MovePosition(new Vector2(transform.position.x, newY));
        }

        private void OnTriggerEnter2D(Collider2D hitInfo)
        {
            if (hitInfo.CompareTag("Border"))
            {
                Destroy(gameObject);
            }
        }
    }
}