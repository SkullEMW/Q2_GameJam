using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject Shop; 

    public bool isPaused;
    void Start()
    {
        PauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
           
        }

        void PauseGame()
        {
            PauseMenu.SetActive(true);
            Shop.SetActive(false);

            Time.timeScale = 0f;
        }

        void ResumeGame()
        {
            PauseMenu.SetActive(false);
            Shop.SetActive(true);

            Time.timeScale = 1f;
        }

        void MainMenu()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("MainMenu");
        }

        void Exit()
        {
            Application.Quit();
        }
    }
}

