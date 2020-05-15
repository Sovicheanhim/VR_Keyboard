using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangePassword : MonoBehaviour
{
    public Text status;
    public InputField inputUser, inputPass, inputNewPass;

    public void OnChangePassword() {
        if (inputUser.text == "" || inputPass.text == "" || inputNewPass.text == "")
        {
            status.text = "Required username and password required*";
        }
        else
        {
            StartCoroutine(tryToChangePassword());
        }
    }

    IEnumerator tryToChangePassword()
    {
        WWWForm form = new WWWForm();
        form.AddField("userName", inputUser.text);
        form.AddField("password", inputPass.text);
        form.AddField("newPass", inputNewPass.text);
        WWW validate = new WWW("http://192.168.7.92/updatePassword.php", form);
        yield return validate;
        string loginstatus = validate.text.TrimEnd();

        if (loginstatus == "DONE")
        {
            PlayerPrefs.SetString("usernameKey", inputUser.text);
            PlayerPrefs.SetString("passwordKey", inputNewPass.text);

            status.text = "Password Changed Successful";
            SceneManager.LoadScene("Setting");
        }
        else
        {
            status.text = "Data Input Incorrect";
        }
    }
}
