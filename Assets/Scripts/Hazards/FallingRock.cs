using System;
using Player;
using UnityEngine;

namespace Hazards
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Draggable))]
    public class FallingRock : MonoBehaviour
    {

        private Rigidbody2D _rb;
        private Draggable _dg;
        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _dg = GetComponent<Draggable>();
        }

        public void Fall()
        {
            _rb.constraints = RigidbodyConstraints2D.None;
            _rb.AddForce(Vector2.down);
            _dg.EnableDrag();
        }

        private void OnTriggerEnter2D(Collider2D other) {
            if (other.tag.Equals("Player")) {
                PlayerDeath playerDeath = other.GetComponent<PlayerDeath>();
                playerDeath.KillPlayer();
            }
        }
    }
}
