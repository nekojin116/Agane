using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //i'm following a crazy man video ngl

    public void PlayGame()
    {
        SceneManager.LoadScene("Levels");
        Debug.Log("Loading levels menu");
    }

    public void QuitGame()
    {
        Application.Quit();

    }

    public void easteregg()
    {
        SceneManager.LoadScene("suguma");
        Debug.Log("dude seriously ?");
    }
}
