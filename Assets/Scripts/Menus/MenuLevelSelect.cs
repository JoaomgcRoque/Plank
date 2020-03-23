using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuLevelSelect : MonoBehaviour
{
    [SerializeField] private int index;
    public void SceneLoader(int SceneIndex)
    {
        Time.timeScale = 1f;
        //SceneManager.LoadScene(SceneIndex);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LevelLoader() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + index);
    }
}
