using System;
using UnityEngine;
using UnityEngine.Events;

namespace Player {
    public class PlayerDeath : MonoBehaviour {
        private UnityEvent _playerDeathEventHandler;
        private Rigidbody2D _rb;
        private BoxCollider2D _bc;
        [SerializeField] private float getThrow;
        
        private void Awake() {
            _playerDeathEventHandler = new UnityEvent();
            _rb = GetComponent<Rigidbody2D>();
            _bc = GetComponent<BoxCollider2D>();
        }


        public void SubscribeToDeathEvents(UnityAction action) {
            _playerDeathEventHandler.AddListener(action);
        }

        public void UnsubscribeToDeathEvents(UnityAction action) {
            _playerDeathEventHandler.RemoveListener(action);
        }

        public void KillPlayer() {
            _playerDeathEventHandler.Invoke();
            _rb.AddForce(new Vector2(0, getThrow), ForceMode2D.Force);
            // _rb.angularVelocity = 5;
            _bc.enabled = false;
        }
        
        
        
    }
}