using System;
using Player;
using Unity.VisualScripting;
using UnityEngine;

namespace Hazards
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class FallingRockController : MonoBehaviour
    {
        [SerializeField] protected Vector2 hitDetectionSize;
        [SerializeField] private float hitDetectionDistance;
        [SerializeField] private LayerMask playerLayer;
        private FallingRock _fallingRock;
        private BoxCollider2D _bc;
        
        void Awake()
        {
            _fallingRock = transform.GetChild(0).GetComponent<FallingRock>();
            _bc = GetComponent<BoxCollider2D>();
        }

        // private void FixedUpdate() {
        //        DetectPlayer(); 
        // }

        // private void DetectPlayer() {
        //     RaycastHit2D hitInfo = Physics2D.BoxCast(
        //         transform.position,
        //         hitDetectionSize,
        //         0,
        //         transform.up,
        //         hitDetectionDistance,
        //         playerLayer
        //     );
        //     GameObject gameObject = hitInfo.collider.gameObject;
        //     if (gameObject.tag.Equals("Player")) {
        //         PlayerDeath playerDeath = gameObject.GetComponent<PlayerDeath>();
        //         playerDeath.KillPlayer();
        //     }
        // }
        //
        // private void OnDrawGizmos() {
        //     Gizmos.DrawWireCube(transform.position + transform.up * hitDetectionDistance, hitDetectionSize);
        // }
        //
        void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (collider2D.CompareTag("Player"))
            {
                
                _fallingRock.Fall();
                _bc.enabled = false;
            }
        }

    }
}
