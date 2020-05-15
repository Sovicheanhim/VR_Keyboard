using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckInternetConnection : MonoBehaviour
{
    WWW www;
    public bool IsConnected;
    IEnumerator Start()
    {
        www = new WWW("http://google.com");
        yield return www;

        if (www.error == null)
        {
            IsConnected = true;
            Debug.Log(IsConnected);
        }
        else
        {
            IsConnected = false;
            Debug.Log(IsConnected);
        }

        GameObject.Find("Script Manager").GetComponent<dbread>().enabled = true;
        DontDestroyOnLoad(this);
    }
}
