using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneChange : MonoBehaviour
{


    public void changeToGameScene()
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }

    public void changeToMenuScene()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

    public void closeApplication()
    {
        Application.Quit();
    }
}
