using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CorrectWordFilter : MonoBehaviour
{
    CheckInternetConnection Connection;

    public Texture correct;
    public GameObject loading;

    WWWForm form;
    WWW www;
    public string[] und = new string[30];

    void Start()
    {
        Connection = GameObject.Find("InternetManager").GetComponent<CheckInternetConnection>();

        form = new WWWForm();

        if(Connection.IsConnected)
        {
            StartCoroutine(FetchUndWord());
        }
    }

    void Ready()
    {
        loading.SetActive(false);

        und = www.text.Split(';');

        for (int i = 0; i < und.Length; i++)
        {
            GameObject temp = GameObject.Find(und[i]);
            if (temp != null)
            {
                temp.GetComponent<RawImage>().texture = correct;
            }   
        }
    }

    IEnumerator FetchUndWord()
    {
        loading.SetActive(true);

        form.AddField("userName", PlayerPrefs.GetString("usernameKey").ToString());
        www = new WWW("http://192.168.7.92/FetchUndWord.php", form);
        yield return www;
        
        Ready();
    }
}
