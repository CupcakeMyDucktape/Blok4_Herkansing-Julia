﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIScript: MonoBehaviour {

    //Tutorial used; https://www.youtube.com/watch?v=JivuXdrIHK0

    public static bool GameIsPaused = false;

    public GameObject PauseUI;
    public GameObject GameOverUI;

	void Update () {

        // Pause menu
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (GameIsPaused) {
                Resume();
            }
            else {
                Pause();
            }
        }
	}

    public void Resume() {
        PauseUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause() {
        PauseUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");

    }

    public void QuitGame() {
        Application.Quit();
    }

    public void GameOver() {
        //Time.timeScale = 0f;
        GameOverUI.SetActive(true);

    }
}
