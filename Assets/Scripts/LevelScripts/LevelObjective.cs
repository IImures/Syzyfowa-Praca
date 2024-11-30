using System;
using UnityEngine;

namespace LevelScripts {
    public class LevelObjective : MonoBehaviour {
        private void OnTriggerEnter2D(Collider2D other) {
            if (other.tag.Equals("Player")) {
                print("test");
            }
        }
    }
}