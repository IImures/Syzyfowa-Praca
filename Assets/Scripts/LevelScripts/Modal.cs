using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


namespace LevelScripts {
    public class Modal : MonoBehaviour {
        private int alpha;
        private CanvasGroup canvasGroup;
        public float fadeDuration = 1f;

        private void Awake() {
            canvasGroup = GetComponent<CanvasGroup>();
        }
        
        
        private void Update() { }

        public void activateModal() {
            alpha = 0;
            Time.timeScale = 0.5f;
            StartCoroutine(FadeIn());
        }

        private IEnumerator FadeIn() {
            float elapsed = 0f;

            while (elapsed < fadeDuration) {
                elapsed += Time.deltaTime;
                float alpha = Mathf.Clamp01(elapsed / fadeDuration);

                if (canvasGroup != null) {
                    canvasGroup.alpha = alpha; // Adjust transparency
                }

                yield return null;
            }

            if (canvasGroup != null) {
                canvasGroup.alpha = 1; // Ensure fully visible at the end
            }
        }
    }
}