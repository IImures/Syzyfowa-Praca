using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(CircleCollider2D))]
    public class PlayerMovement : MonoBehaviour
    {

        private bool _movementDisabled;
        private bool _isGrounded;
        private bool _isTouchingWall;
        private Vector2 _wallDirection;
        private float _xInput;
        private float _currentVelocity;


        private Rigidbody2D _rb;

        [SerializeField]private PlayerConfig playerConfig;


        public void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }
        
        public void Update()
        {
            _xInput = Input.GetAxis("Horizontal");
            
            Flip();
        }
        
        public void FixedUpdate()
        {
            if(_movementDisabled) return;
            Move();
        }
        
        private void Move()
        {
            float targetSpeed = _xInput *  playerConfig.speed;
            float smoothTime = Mathf.Abs(targetSpeed) > 0.1f ? playerConfig.acceleration : playerConfig.deceleration;
            _currentVelocity = Mathf.SmoothDamp(_currentVelocity, targetSpeed, ref _currentVelocity, smoothTime * Time.fixedDeltaTime);
            _rb.velocity = new Vector2(_currentVelocity, _rb.velocity.y);
        }

        private void Flip(){
            if(_movementDisabled) return;
            
            if (_xInput != 0)
            {
                transform.localScale = new Vector3(Mathf.Sign(_xInput) * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
        }

        private void OnCollisionStay2D(Collision2D collision)
        {
            GroundCheck(collision);
            WallCheck(collision);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            GroundCheck(collision);
            WallCheck(collision);
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            _isGrounded = false;
            _isTouchingWall = false;
        }

        
        private void GroundCheck(Collision2D collision)
        {
            _isGrounded = false;
            foreach (ContactPoint2D contact in collision.contacts)
            {
                if (contact.normal.y > 0.5f)
                {
                    _isGrounded = true;
                    break;
                }
            }
        }
        
        private void WallCheck(Collision2D collision)
        {
            _isTouchingWall = false;
            _wallDirection = Vector2.zero;
            foreach (ContactPoint2D contact in collision.contacts)
            {
                if (Mathf.Abs(contact.normal.x) > 0.5f && !_isGrounded && _rb.velocity.y < 0)
                {
                    _isTouchingWall = true;
                    _wallDirection = contact.normal;
                    break;
                }
            }
        }
        
    }
}
