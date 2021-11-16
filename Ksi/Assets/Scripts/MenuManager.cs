using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Toggle = UnityEngine.UI.Toggle;

public class MenuManager : MonoBehaviour
{
    public Toggle fullscreenToggle;
    public Toggle vSyncToggle;
    public Sprite checkbox_on;
    public Sprite checkbox_off;
    public TMPro.TMP_Dropdown dropResolution;

    private void Start()
    {
        fullscreenToggle.isOn = Screen.fullScreen;

        if (QualitySettings.vSyncCount == 0)
        {
            vSyncToggle.isOn = false;
        }
        else
        {
            vSyncToggle.isOn = true;
        }
    }

    public void LoadMain() 
    {
        SceneManager.LoadScene(0);
    }    
    
    public void LoadGame() 
    {
        SceneManager.LoadScene(1);
    }

    public void LoadOptions() 
    {
        SceneManager.LoadScene(2);
    }

    public void LoadBack()
    {
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void ResolutionChange()
    {
        if (dropResolution.value == 0) Screen.SetResolution(1920,1080,false);
        else if (dropResolution.value == 1) Screen.SetResolution(1600,900,false);
        else if (dropResolution.value == 2) Screen.SetResolution(1280,720,false);
    }

    public void FullscreenChange()
    {
        if (fullscreenToggle.isOn)
        {
            Screen.fullScreen = true;
            fullscreenToggle.image.sprite = checkbox_on;

        }
        else
        {
            Screen.fullScreen = false;
            fullscreenToggle.image.sprite = checkbox_off;
        }
    }

    public void VSyncChange()
    {
        if (vSyncToggle.isOn)
        {
            QualitySettings.vSyncCount = 1;
            vSyncToggle.image.sprite = checkbox_on;
        }
        else
        {
            QualitySettings.vSyncCount = 0;
            vSyncToggle.image.sprite = checkbox_off;
        }
    }


}