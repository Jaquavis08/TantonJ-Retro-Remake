using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStart : MonoBehaviour
{
    public void LoadScene1(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadScene2(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}