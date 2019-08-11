using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIScript : MonoBehaviour {

    //Tutorial used; https://www.youtube.com/watch?v=JivuXdrIHK0

    static bool GameIsPaused = false;

    [Header("All UI's")]
    [Tooltip("Sleep hier alle UI's in om aan te roepen.")]
    public GameObject PauseUI;
    public GameObject GameOverUI;
    public GameObject WinScreen;
    public GameObject InGameUI;

    [Header("Collectable")]
    [Tooltip("Dit gaat om de collectables. Hiervoor word een Singleton gebruikt.")]
    public TextMeshProUGUI CollectableProgress;

    [Header("Time")]
    [Tooltip("Dit gaat over de timer.")]
    public float TimeLeft = 100f;
    public TextMeshProUGUI TimeText;

    private void Awake() {
        //InGameUI.GetComponent<>();
        InGameUI.SetActive(true);

    }

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

        //Collectable update
        CollectableProgress.text = Singleton.Instance.Collectables.ToString() + " / " + 5;

        

        //TimeLeft -= 1 * Time.deltaTime;
        //TimeText.text = TimeLeft.ToString();
    }

    void Pause() {
        PauseUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        InGameUI.SetActive(false);
    }

    public void Resume() {
        PauseUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        InGameUI.SetActive(true);
    }

    public void Restart() {
        Scene ThisScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(ThisScene.name);
    }

    public void LoadMenu() {
        Debug.Log("Clicked on main menu");
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void GameOver() {
        Time.timeScale = 0f;
        GameOverUI.SetActive(true);
        InGameUI.SetActive(false);
    }

    public void Win() {
        Time.timeScale = 0f;
        WinScreen.SetActive(true);
        InGameUI.SetActive(false);
    }
}
