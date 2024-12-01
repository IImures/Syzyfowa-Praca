using System;
using System.Collections;
using Player;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LevelScripts {
    public class LevelUtility : MonoBehaviour {
        [SerializeField] private GameObject pauseMenu;
        [SerializeField] private PlayerMovement playerMovement;

        [SerializeField] private GameObject levelCompleted;
        private Modal levelCompletedModal;
        [SerializeField] private GameObject failedLevel;

        public void Awake() {
            levelCompletedModal = levelCompleted.GetComponent<Modal>();
        }

        public void Update() {
            if (Input.GetKeyDown(KeyCode.Escape)) {
                pauseMenu.SetActive(!pauseMenu.activeSelf);
                if (pauseMenu.activeSelf) {
                    playerMovement._movementDisabled = true;
                    Time.timeScale = 0;
                }
                else {
                    playerMovement._movementDisabled = false;
                    Time.timeScale = 1;
                }
            }
        }

        public void LevelCompleted() {
            playerMovement._movementDisabled = true;
            StartCoroutine(openLevelCompletedModal());
        }

        private IEnumerator openLevelCompletedModal() {
            yield return new WaitForSeconds(0.8f);
            levelCompleted.SetActive(true);
            levelCompletedModal.activateModal();

        }
        
        
        public void RestartLevel() {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void GoToMainMenu() {
            SceneManager.LoadScene("MainMenu");
        }
        
        public void FailedLevel() {
            failedLevel.SetActive(true);
        }
        
        
    }
}