using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResumeFilter : MonoBehaviour
{
    public void LoadScene()
    {
        string sceneName = PlayerPrefs.GetString("incompleteScene");
        SceneManager.LoadScene(sceneName);
    }
}
