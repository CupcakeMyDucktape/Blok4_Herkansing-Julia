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
    public int TotalCollected = 0;
    GameObject[] Turtles;

    [Header("Time")]
    public TextMeshProUGUI TimeText;
    public float CurrentTime;
    [Tooltip("Dit is hoeveel tijd je mee begint.")]
    public float StartingTime;



    private void Start() {
        InGameUI.SetActive(true);
        CollectableProgress.text = "Save the turtles!";
        CurrentTime = StartingTime;
        if (GameIsPaused) {
            Resume();
            GameIsPaused = false;
        }
        Time.timeScale = 1f;

        Turtles = GameObject.FindGameObjectsWithTag("Collectable");

        FindObjectOfType<AudioManager>().Play("BackgroundWaves");
    }

    void Update () {
        // Pause menu
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (GameIsPaused) Resume();
            else Pause();
        }

        if (GameIsPaused) Time.timeScale = 0f;
        if (!GameIsPaused) Time.timeScale = 1f;

        //Collectable update
        if (TotalCollected >= Turtles.Length) Win();

        //Timer
        CurrentTime -= 1 * Time.deltaTime;
        if (CurrentTime >= 1) TimeText.text = CurrentTime.ToString("F0"); 
        else GameOver();
    }

    public void CollectedSomething() {
        TotalCollected += 1;
        CollectableProgress.text = TotalCollected.ToString() + " / " + Turtles.Length.ToString();
        FindObjectOfType<AudioManager>().Play("TurtleCollected");
    }

    public void GameOver() {
        GameIsPaused = true;
        Time.timeScale = 0f;
        GameOverUI.SetActive(true);
        InGameUI.SetActive(false);
    }

    public void Win() {
        GameIsPaused = true;
        Time.timeScale = 0f;
        WinScreen.SetActive(true);
        InGameUI.SetActive(false);
        CollectableProgress.text = "Turtles saved; " + TotalCollected + " / " + Turtles.Length.ToString();
    }

    // BUTTONS --------------------------------------

    void Pause() {
        PauseUI.SetActive(true);
        GameIsPaused = true;
        InGameUI.SetActive(false);
    }

    public void Resume() {
        PauseUI.SetActive(false);
        GameIsPaused = false;
        InGameUI.SetActive(true);
    }

    public void Tutorial() {
        SceneManager.LoadScene(1);
    }

    public void LoadMenu() {
        SceneManager.LoadScene(0);
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void Level1() {
        SceneManager.LoadScene(2);
    }
}
