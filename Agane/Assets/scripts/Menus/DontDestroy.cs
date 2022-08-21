using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour
{


    // Start is called before the first frame update

    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene.name == "main" || currentScene.name == "Levels")
        {
         DontDestroyOnLoad(gameObject);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}