using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsControls : MonoBehaviour
{
    public static void BackToMenu() {
        SceneManager.LoadScene("MainMenu");
    }

    public void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            BackToMenu();
        }
    }
}
