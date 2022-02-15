using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public GameObject WinUI;

    public void LoadLevel(string name)
    {
        SceneManager.LoadScene(name);
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
