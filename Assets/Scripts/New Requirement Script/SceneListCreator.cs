using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneListCreator : MonoBehaviour
{
    CheckInternetConnection Connection;

    public GameObject ScenePrefab;
    public GameObject LoadingPanel;

    string RawString, ThumbnailPath;
    WWWForm form;

    public string[] AddedData;

    public string[] Word = new string[100];
  
    [System.Obsolete]
    IEnumerator Start()
    {
        Connection = GameObject.Find("InternetManager").GetComponent<CheckInternetConnection>();

        LoadingPanel.SetActive(true);

        form = new WWWForm();
        form.AddField("userName", PlayerPrefs.GetString("usernameKey").ToString());
        if (SceneManager.GetActiveScene().name == "MainScene")
        {
            TextAsset SceneFile = (TextAsset)Resources.Load("SceneName");
            Word = SceneFile.text.Split(';');

            for(int i=0; i<Word.Length -1 ; i++)
            {
                InstantiateCard(i);
            }
        }
        else if(SceneManager.GetActiveScene().name == "Recommend")
        {
            string path = Application.persistentDataPath + "/RecommendScene.txt";

            if(Connection.IsConnected)
            {
                WWW words = new WWW("http://192.168.7.92/readTempScene.php", form);
                yield return words;

                if (!File.Exists(path))
                {
                    DownloadData(path, words);
                }
                else
                {
                    DownloadData(path, words);
                }
            }
            else
            {
                LoadData(path);
            }
        }
        else if(SceneManager.GetActiveScene().name == "Completed")
        {
            WWW words = new WWW("http://192.168.7.92/completedScene.php", form);
            yield return words;
            RawString = words.text;
            Debug.Log(RawString);

            Word = RawString.Split(';');

            for (int i = 0; i < Word.Length - 1; i++)
            {
                InstantiateCard(i);
            }
        }
        LoadingPanel.SetActive(false);
    }

    public void DownloadData(string path, WWW words)
    {
        File.WriteAllText(path, "");
        
        RawString = words.text;
        Debug.Log(RawString);

        Word = RawString.Split(';');

        for (int i = 0; i < Word.Length - 1; i++)
        {
            InstantiateCard(i);
            File.AppendAllText(path, Word[i] + "\n");
        }
    }

    public void LoadData(string path)
    {
        Word = File.ReadAllText(path).Split('\n');

        for (int i = 0; i < Word.Length - 1; i++)
        {
            InstantiateCard(i);
        }
    }

    public void InstantiateCard(int i)
    {
        //instantiate scene card
        GameObject newitems = Instantiate<GameObject>(ScenePrefab, transform);
        //set scene name
        newitems.name = Word[i];
        //scene thumbnail path
        ThumbnailPath = "Scene_Thumbnail/" + Word[i];
        //set image to card
        newitems.GetComponent<RawImage>().texture = Resources.Load(ThumbnailPath) as Texture;
    }
}
