using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(BoxCollider2D))]
    public class PlayerMovement : MonoBehaviour
    {

        private bool _movementDisabled;
        private bool _isGrounded;
        private bool _isTouchingWall;
        private bool _canMoveVertically;
        private Vector2 _wallDirection;
        private float _xInput;
        private float _yInput;
        private float _currentVelocity;
        private float _rayLength =2.0f;


        private Rigidbody2D _rb;
        
        [SerializeField]private LayerMask groundLayer;
        [SerializeField]private PlayerConfig playerConfig;


        public void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }
        
        public void Update()
        {
            _xInput = Input.GetAxis("Horizontal");
            _yInput = Input.GetAxis("Vertical");
            AlignToSlope();
            Flip();
        }
        
        public void FixedUpdate()
        {
            if(_movementDisabled) return;
            Move();
            if(_canMoveVertically){
                Climb();
            }
        }
        
        void AlignToSlope()
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, _rayLength, groundLayer);

            if (hit.collider != null)
            {
                Vector2 slopeNormal = hit.normal;
                float targetAngle = Mathf.Atan2(slopeNormal.y, slopeNormal.x) * Mathf.Rad2Deg;
                float currentAngle = transform.eulerAngles.z;
                float smoothedAngle = Mathf.LerpAngle(currentAngle, targetAngle - 90, Time.deltaTime * 5); // 5 is rotation time
                transform.rotation = Quaternion.Euler(0, 0, smoothedAngle);
            }
            else
            {
                float smoothedAngle = Mathf.LerpAngle(transform.eulerAngles.z, 0, Time.deltaTime * 5);
                transform.rotation = Quaternion.Euler(0, 0, smoothedAngle);
            }
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

        private void Climb()
        {
            Debug.Log("Climb");
            transform.position = new Vector2(transform.position.x,transform.position.y + _yInput * playerConfig.climbSpeed);
            _rb.velocity = new Vector2(_currentVelocity, 0);
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
            KillCheck(collision);
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
        
        private void KillCheck(Collision2D collision) {
            if (collision.gameObject.name == "KillAnt") {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name); //resetuj scenę
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

        public void ToggleVerticalMovement()
        {
            _canMoveVertically = !_canMoveVertically;
            _rb.gravityScale = _canMoveVertically?0:1;
            Debug.Log("toggle to "+_canMoveVertically);
        }
        
    }
}
