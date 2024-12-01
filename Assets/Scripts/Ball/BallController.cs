using System;
using Player;
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

        private Vector2 _dragDirection;
        private bool _isDragging = false;
        public float followSpeed = 2f;

        void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _circleCollider = GetComponent<CircleCollider2D>();
        }

        private void FixedUpdate()
        {
            if (!_isDragging) return;
            if (player.GetComponent<PlayerMovement>().MovingVertically)
            {
                VerticalMoveNearPlayer();
            }
            else
            {
                HorizontalMoveNearPlayer();
            }
            _rb.gravityScale = _isDragging ? 0 : 1;
        }

        public void ToggleDrag()
        {
            _isDragging = !_isDragging;
            _dragDirection = new Vector2(Math.Sign(player.localScale.x),Math.Sign(player.localScale.y));
            
        }


        public void HorizontalMoveNearPlayer()
        {
            if (_dragDirection.x != Math.Sign(player.localScale.x))
            {
                _isDragging = false;
                return;
            }
            Vector2 targetPosition = Vector2.MoveTowards(
                transform.position,
                player.position - new Vector3(_dragDirection.x * -1, 0, 0),
                Vector2.Distance(transform.position, player.position)
            );
            _rb.MovePosition(targetPosition);
        }

        public void VerticalMoveNearPlayer()
        {
            if (_dragDirection.y != Math.Sign(player.localScale.y))
            {
                _isDragging = false;
                return;
            }

            if(player.position.y>transform.position.y){
                transform.position=Vector2.MoveTowards(
                    transform.position,
                    new Vector2(player.position.x,player.position.y-1),
                    Vector2.Distance(transform.position, player.position)
                );
            }
            
        }
    }
}
