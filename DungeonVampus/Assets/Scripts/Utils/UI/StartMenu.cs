using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(0);
        Debug.Log("loaded");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
