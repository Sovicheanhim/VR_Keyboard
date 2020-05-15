using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class dbread : MonoBehaviour
{
    //login error indicator
    public Text status;
    public InputField inputUser, inputPass;
    string[] BookmarkedWord;
    /*int currentID;
    // show registered users list
    string dbstring;
    public string[] registeredUsers;
    public string[] usernames = new string[10000];
    public string[] passwords = new string[10000];
    string saveUsername, savePassword; 
    bool wrongUsername;*/

    /*IEnumerator Start()
    {
        WWW users = new WWW("http://192.168.7.92/read.php");
        yield return users;
        dbstring = users.text;
        registeredUsers = dbstring.Split(';');
        for (int i = 0; i < registeredUsers.Length - 1; i++)
        {
            usernames[i] = registeredUsers[i].Substring(registeredUsers[i].IndexOf("U") + 9);
            usernames[i] = usernames[i].Remove(usernames[i].IndexOf('|'));
            passwords[i] = registeredUsers[i].Substring(registeredUsers[i].IndexOf("Password") + 9);
        }
        savingUserState();
    }*/

    // PlayerPrefCache system
    void Start()
    {
        if(PlayerPrefs.GetString("usernameKey").ToString() != "" && PlayerPrefs.GetString("passwordKey").ToString() != "")
        {
            SceneManager.LoadScene("Recommend");
        }
    }

    IEnumerator TrytoLogin()
    {
        WWWForm form = new WWWForm();
        form.AddField("userName", inputUser.text);
        form.AddField("password", inputPass.text);
        WWW validate = new WWW("http://192.168.7.92/read.php", form);
        yield return validate;
        string loginstatus = validate.text.TrimEnd();

        if(loginstatus == "DONE")
        {
            PlayerPrefs.SetString("usernameKey", inputUser.text);
            PlayerPrefs.SetString("passwordKey", inputPass.text);

            status.text = "Login Successful";
            string path = Application.persistentDataPath + "/BookmarkWord.txt";
            validate = new WWW("http://192.168.7.92/readBookmark.php", form);
            
            if(validate.text.TrimEnd() == "None")
            {
                File.WriteAllText(path, "");
            }
            else
            {
                File.WriteAllText(path, validate.text);
            }
            SceneManager.LoadScene("Recommend");
        }
        else
        {
            status.text = "Password is incorrect";
        }
    }
    public void Login()
    {
        if (inputUser.text == "" || inputPass.text == "")
        {
            status.text = "Required username and password required*";
        }
        else
        {
            StartCoroutine(TrytoLogin());
        }

    }
}
