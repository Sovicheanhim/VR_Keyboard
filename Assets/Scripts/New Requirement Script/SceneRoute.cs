using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.IO;

public class SceneRoute : MonoBehaviour
{
    public string CurrentSceneBtnClicked;

    public void OnSignUpButtonClicked()
    {
        SceneManager.LoadScene("Sign_Up_scene");
    }
    public void OnRecommandBtnClicked()
    {
       SceneManager.LoadScene("Recommend");
    }

    public void OnAllBtnClicked()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void OnCompletedBtnClicked()
    {
        SceneManager.LoadScene("Completed");
    }

    public void OnSceneButtonClicked()
    {
        CurrentSceneBtnClicked = EventSystem.current.currentSelectedGameObject.name;

        WWWForm form = new WWWForm();
        form.AddField("sceneName", CurrentSceneBtnClicked);
        form.AddField("userName", PlayerPrefs.GetString("usernameKey").ToString());
        WWW update = new WWW("http://192.168.7.92/insertToDisplaySceneTable.php", form);

        SceneManager.LoadScene(CurrentSceneBtnClicked);
    }

    public void Logout()
    {
        PlayerPrefs.SetString("usernameKey", "");
        PlayerPrefs.SetString("passwordKey", "");

        File.Delete(Application.persistentDataPath + "/RecommendScene.txt");
        #if UNITY_EDITOR
            UnityEditor.AssetDatabase.Refresh();
        #endif

        SceneManager.LoadScene("Log_in");
    }

    public void OnTestSceneBtnClicked()
    {
        SceneManager.LoadScene("Test");
    }

    public void OnSettingBtnClicked()
    {
        SceneManager.LoadScene("Setting");
    }

    public void OnChangePasswordBtnClicked()
    {
        SceneManager.LoadScene("ChangePassword");
    }

    public void OnBookmarkBtnClicked()
    {
        SceneManager.LoadScene("Bookmark");
    }
}
