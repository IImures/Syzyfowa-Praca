using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


namespace LevelScripts {
    public class Modal : MonoBehaviour {
        private int alpha;
        private CanvasGroup canvasGroup;
        private void Awake() {
            canvasGroup = GetComponent<CanvasGroup>();
        }

        private void Update() {
        }

        public void activateModal() {
            alpha = 0;
            Time.timeScale = 0.5f;
            StartCoroutine(FadeIn());
        }

        private IEnumerator FadeIn() {
            while (alpha < 255) {
                alpha += 255 / 60;
                setAlpha(alpha);
                yield return new WaitForSeconds(1 / 60);
            }
        }
        
        public void setAlpha(float alpha) {
            canvasGroup.alpha = alpha;
        }
        
    }
}