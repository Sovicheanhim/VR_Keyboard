using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNewTableForUser : MonoBehaviour
{
    public void getUserName(string username)
    {
        WWWForm form = new WWWForm();
        form.AddField("usernamePost", username);

        WWW register = new WWW("http://192.168.7.92/createNewTable.php", form);
    }
}
