using System;
using UnityEngine;
using UnityEngine.Events;

namespace Player {
    public class PlayerDeath : MonoBehaviour {
        private UnityEvent _playerDeathEventHandler;

        private void Awake() {
            _playerDeathEventHandler = new UnityEvent();
        }


        public void SubscribeToDeathEvents(UnityAction action) {
            _playerDeathEventHandler.AddListener(action);
        }

        public void UnsubscribeToDeathEvents(UnityAction action) {
            _playerDeathEventHandler.RemoveListener(action);
        }

        public void KillPlayer() {
            _playerDeathEventHandler.Invoke();
        }
        
        
        
    }
}