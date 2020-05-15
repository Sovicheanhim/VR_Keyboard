using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SignUp : MonoBehaviour
{
    public Text status;
    public InputField nameInput, passwordInput;

    IEnumerator tryToRegister()
    {
        status.text = "Loading";

        WWWForm form = new WWWForm();
        form.AddField("usernamePost", nameInput.text);
        form.AddField("passwordPost", passwordInput.text);
        WWW register = new WWW("http://192.168.7.92/insertuser.php", form);
        yield return register;
        string signupstatus = register.text.TrimEnd();

        if(signupstatus == "DONE")
        {
            PlayerPrefs.SetString("usernameKey", nameInput.text);
            PlayerPrefs.SetString("passwordKey", passwordInput.text);

            WWW createTable = new WWW("http://192.168.7.92/createNewTable.php", form);

            string path = Application.persistentDataPath + "/BookmarkWord.txt";
            File.WriteAllText(path, "");
            SceneManager.LoadScene("Test");
        }
        else
        {
            status.text = "Username is already taken";
        }
    }

    public void Register()
    {
        if (nameInput.text == "" || passwordInput.text == "")
        {
            status.text = "Data Required*";
        }
        else
        {
            StartCoroutine(tryToRegister());
        }
    }
}
