using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMainMenu : MonoBehaviour {

    private void Awake() {
        Time.timeScale = 1f;
    }

    public void StartGame() {
        SceneManager.LoadScene(2);
    }

    public void Tutorial() {
        SceneManager.LoadScene(1);
    }

    public void QuitGame() {
        Application.Quit();
    }
}
