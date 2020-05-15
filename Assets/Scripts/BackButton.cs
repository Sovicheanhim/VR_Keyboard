using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    public void BacktoListRoom(){
        SceneManager.LoadScene("MainScene");
    }
    public void LogOut(){
        SceneManager.LoadScene("FirstScene");
    }
    public void ChangePasswordSetting(){
        SceneManager.LoadScene("ChangePassword");
    }
    public void BookmarkButton(){
        SceneManager.LoadScene("BookmarkList");
    }
    public void HomeButton()
    {
        SceneManager.LoadScene("Mainscene");
    }

    public void BacktoLogin()
    {
        SceneManager.LoadScene("Log_in");
    }
    
}
