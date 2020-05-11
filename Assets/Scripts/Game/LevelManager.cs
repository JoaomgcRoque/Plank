using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int numberofdead;
    [SerializeField] public int maxdead;
    [SerializeField] private GameObject WinMenu;
    [SerializeField] private float wintime;
    [SerializeField] private float destroytime;

    private void Awake() {
        WinMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    private void Update() {
        if (numberofdead == maxdead) {
            //Win();
            StartCoroutine(DestroyTime());
            StartCoroutine(WinTime());
        }
    }

    private void Win() {
        StopCoroutine(WinTime());
        WinMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void NextIsland() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;
    }

    public void ReturnMenu() {
        SceneManager.LoadScene("StartMenu");
    }

    public void DestroyAllEnemies() {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies) {
            GameObject.Destroy(enemy);
        }
        StopCoroutine(DestroyTime());
    }

    IEnumerator DestroyTime() {
        yield return new WaitForSeconds(destroytime);
        DestroyAllEnemies();
    }

    IEnumerator WinTime() {
        yield return new WaitForSeconds(wintime);
        Win();
    }
}
