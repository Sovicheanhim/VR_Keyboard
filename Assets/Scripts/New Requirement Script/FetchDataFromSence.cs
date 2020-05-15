using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class FetchDataFromSence : MonoBehaviour
{
    CheckInternetConnection Connection;

    public int i;
    string RawString;

    public string[] Word = new string[30];

    public GameObject loading;
    [System.Obsolete]
    IEnumerator Start()
    {
        Connection = GameObject.Find("InternetManager").GetComponent<CheckInternetConnection>();

        loading.SetActive(true);

        string path = Application.persistentDataPath + "/" + SceneManager.GetActiveScene().name + ".txt";

        if(Connection.IsConnected)
        {
            if (!File.Exists(path))
            {
                File.WriteAllText(path, "");

                WWWForm form = new WWWForm();
                WWW words;

                form.AddField("userName", PlayerPrefs.GetString("usernameKey").ToString());
                words = new WWW("http://192.168.7.92/readVocabularyOnly.php", form);
                yield return words;
                Debug.Log("Complete");

                RawString = words.text;
                Debug.Log(RawString);

                Word = RawString.Split(';');

                for (i = 0; i < Word.Length - 1; i++)
                {
                    File.AppendAllText(path, Word[i] + "\n");
                }
                Debug.Log("Success");
            }
            else
            {
                Debug.Log("Local");
                Word = File.ReadAllText(path).Split('\n');
            }

            GetComponent<CorrectWordFilter>().enabled = true;
        }
        else
        {
            if (!File.Exists(path))
            {
                loading.SetActive(false);
            }
            else
            {
                Word = File.ReadAllText(path).Split('\n');
            }
        }

        loading.SetActive(false);

        GetComponent<Understood>().enabled = true;
    }
}