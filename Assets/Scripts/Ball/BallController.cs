using System;
using UnityEngine;

namespace Ball
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(CircleCollider2D))]
    public class BallController : MonoBehaviour
    {
        private CircleCollider2D _circleCollider;
        private Rigidbody2D _rb;
        [SerializeField] private Transform player;

        private float _dragDirection;
        private bool _isDragging = false;
        public float followSpeed = 2f;
        public float stopDistance = 1f;

        void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _circleCollider = GetComponent<CircleCollider2D>();
        }

        private void FixedUpdate()
        {
            if (!_isDragging) return;
            MoveNearPlayer();
            
        }

        public void ToggleDrag()
        {
            _isDragging = !_isDragging;
            _dragDirection = Math.Sign(player.localScale.x);
        }


        public void MoveNearPlayer()
        {
            // float distance = Vector2.Distance(transform.position, player.position);

            if (_dragDirection != Math.Sign(player.localScale.x))
            {
                _isDragging = false;
                return;
            }
            //
            // if (true)
            // {
                Vector2 targetPosition = Vector2.MoveTowards(
                    transform.position,
                    player.position - new Vector3(_dragDirection * -1, 0,0),
                    followSpeed * Time.deltaTime
                );
                _rb.MovePosition(targetPosition);
            // }
            // else
            // {
            //     _rb.velocity = Vector2.Lerp(_rb.velocity, Vector2.zero, 0.1f);
            // }
        }

    }
}
