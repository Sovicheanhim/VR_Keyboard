using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShowControlButton : MonoBehaviour
{
    public GameObject VocabularyBtnCollection;
    public GameObject ControlBtnCollection;
    public GameObject VocabularyCard;
    public Sprite Unbookmark;
    public Sprite Bookmarks;
    public Button btnBookmark;

    public GameObject CurrentVocabularyBtnClicked;
    public string CurrentVocabularyBtnClickedName;
    public string[] Word;

    CheckInternetConnection Connection;
    IEnumerator Start()
    {
        Connection = GameObject.Find("InternetManager").GetComponent<CheckInternetConnection>();

        Default();

        string path = Application.persistentDataPath + "/BookmarkWord.txt";
        if (!File.Exists(path))
        {
            if (Connection.IsConnected)
            {
                WWWForm form = new WWWForm();
                form.AddField("user", PlayerPrefs.GetString("usernameKey").ToString());

                WWW www = new WWW("http://192.168.7.92/readBookmark.php", form);
                yield return www;

                Word = www.text.Split(';');
                File.WriteAllText(path, www.text);
            }
        }
        else
        {
            Word = File.ReadAllText(path).Split(';');
        }
    }

    public void Default()
    {
        VocabularyBtnCollection.SetActive(true);
        ControlBtnCollection.SetActive(false);
        VocabularyCard.SetActive(false);
    }

    public void OnBtnVocabularyClicked()
    {
        CurrentVocabularyBtnClicked = EventSystem.current.currentSelectedGameObject;
        CurrentVocabularyBtnClickedName = CurrentVocabularyBtnClicked.name;

        VocabularyBtnCollection.SetActive(false);
        ControlBtnCollection.SetActive(true);

        if (Word.Contains(CurrentVocabularyBtnClickedName))
        {
            btnBookmark.GetComponent<Image>().sprite = Unbookmark;
        }
        else
        {
            btnBookmark.GetComponent<Image>().sprite = Bookmarks;
        }
    }
}
