using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int numberofdead;
    [SerializeField] private int maxdead;
    [SerializeField] private GameObject WinMenu;

    private void Awake() {
        WinMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    private void Update() {
        if (numberofdead == maxdead) {
            Win();
        }
    }

    private void Win() {
        WinMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void NextIsland() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    /*public void Pause() {
        PauseCanvas.SetActive(true);
        Time.timeScale = 0f;
        Paused = true;
    }*/
}
