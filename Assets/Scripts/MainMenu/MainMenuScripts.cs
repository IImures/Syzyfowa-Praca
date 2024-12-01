using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScripts : MonoBehaviour
{
    public static void PlayGame() {
        SceneManager.LoadScene("Disclaimer");
    }

    public static void OpenCredits() {
        SceneManager.LoadScene("Credits");
    }

    public static void OpenHowToPlay() {
        SceneManager.LoadScene("HowToPlay"); 
    }

    public static void OpenSettings() {
        
    }
}
