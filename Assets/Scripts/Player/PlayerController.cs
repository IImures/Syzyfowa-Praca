using Ball;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {

        [SerializeField] private LayerMask ballLayer;

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                CheckForBalls();
            }
        }

        void CheckForBalls()
        {
            Vector2 checkRange = (Vector2)transform.position + new Vector2((1f) * Mathf.Sign(transform.localScale.x), 0);// 1.75f for offset
            Collider2D ballRayCast = Physics2D.OverlapCircle(checkRange, 0.75f, ballLayer);
            if (!ballRayCast) return;
            ballRayCast.GetComponent<BallController>().ToggleDrag();
        }
        
        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Vector2 attackPosition = (Vector2)transform.position + new Vector2((1f) * Mathf.Sign(transform.localScale.x), 0); // 0.5 is offset of attack
            Gizmos.DrawWireSphere(attackPosition, 0.75f);
        }
    }
}