using System;
using UnityEngine;

namespace LevelScripts {
    public class LevelObjective : MonoBehaviour {
        [SerializeField] private LevelUtility levelUtility;
        private Animator _animator;

        private void Awake() {
            _animator = GetComponent<Animator>();
        }

        private void OnTriggerEnter2D(Collider2D other) {
            if (other.tag.Equals("Ball")) {
                levelUtility.LevelCompleted();
                _animator.Play("FlowerActivated");
            }
        }
    }
}