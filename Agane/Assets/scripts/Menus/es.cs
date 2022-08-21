using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class es : MonoBehaviour
{
    public int sceneIndex;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneIndex);
        }
    }
}
