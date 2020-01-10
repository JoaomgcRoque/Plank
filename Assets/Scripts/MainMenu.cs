using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class _MainMenu : MonoBehaviour
{
    public string _levelName;

    public void _PlayGame()
    {
        SceneManager.LoadScene(_levelName);
    }

    public void _QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
