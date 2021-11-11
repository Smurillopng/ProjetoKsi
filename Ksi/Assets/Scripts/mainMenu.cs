using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainMenu : MonoBehaviour
{
    public void LoadGame() {
        SceneManager.LoadScene(1);
    }

    public void LoadOptions() {
        SceneManager.LoadScene(2);
    }

    public void LoadMain() {
        SceneManager.LoadScene(0);
    }

    public void ToggleFullscreen() {
        Screen.fullScreen = !Screen.fullScreen;
    }
}
