using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenu;
    private static bool isPaused;
    Scene telaAtual;
    string nomeCena;
    void Start()
    {
        telaAtual = SceneManager.GetActiveScene();
        nomeCena = telaAtual.name;
        pauseMenu.SetActive(false);
    }
    
    void Update()
    {
        if (nomeCena == "Game")
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (isPaused)
                {
                    ContinueGame();
                }
                else
                {
                    PauseGame();
                }
            }
        } else if (nomeCena == "MainMenu")
        {
            if (isPaused)
            {
                ContinueGame();
            }
            else
            {
                PauseGame();
            }
        }
        
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ContinueGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
}
