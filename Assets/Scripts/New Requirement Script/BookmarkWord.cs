/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class BookmarkWord : MonoBehaviour
{
    public GameObject ScenePrefab;

    public string[] Word = new string[100];

    void Start()
    {
        string path = Application.persistentDataPath + "/BookmarkWord.txt";
        Word = File.ReadAllText(path).Split(';');

        for (int i = 0; i < Word.Length - 1; i++)
        {
            InstantiateCard(i);
        }
    }

    /*public void DownloadData(string path, WWW words)
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
    }*/

    /*public void LoadData(string path)
    {
        Word = File.ReadAllText(path).Split('\n');

        for (int i = 0; i < Word.Length - 1; i++)
        {
            InstantiateCard(i);
        }
    }*/
/*
    public void InstantiateCard(int i)
    {
        string path = Application.persistentDataPath + "/" + Word[i] + "_photo.txt";
        byte[] Bytes = GetImage(path);
        Texture2D texture = new Texture2D(100, 100);
        texture.LoadImage(Bytes);
        texture.Apply();

        GameObject newitems = Instantiate<GameObject>(ScenePrefab, transform);
        newitems.name = Word[i];
        newitems.GetComponent<RawImage>().texture = texture;
    }

    public byte[] GetImage(string path)
    {
        return File.ReadAllBytes(path);
    }
}
*/