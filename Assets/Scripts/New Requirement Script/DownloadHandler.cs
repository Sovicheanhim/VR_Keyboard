using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DownloadHandler : MonoBehaviour
{
    public GameObject sceneCollection;

    string[] Word = new string[30];

    IEnumerator Start()
    {
        DontDestroyOnLoad(this);

        WWWForm form = new WWWForm();
        WWW www;

        foreach(Transform child in transform)
        {
            string path = Application.persistentDataPath + "/" + child.name + ".txt";

            if (!File.Exists(path))
            {
                File.WriteAllText(path, "");

                form.AddField("scene", child.name);
                www = new WWW("http://192.168.7.92/readVocabularyOnly.php", form);
                yield return www;

                Word = www.text.Split(';');

                foreach(string w in Word)
                {
                    File.AppendAllText(path, w);
                }
            }
            else
            {
                continue;
            }
        }

        Destroy(this);
    }
}
