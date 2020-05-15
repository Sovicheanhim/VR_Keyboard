/*using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Bookmark : MonoBehaviour
{
    public ShowControlButton BookmarkBtn;
    CheckInternetConnection Connection;
    WWWForm form;
    WWW update;

    List<string> word = new List<string>();

    void Start()
    {
        form = new WWWForm();
        Connection = GameObject.Find("InternetManager").GetComponent<CheckInternetConnection>();
        word.AddRange(BookmarkBtn.Word);
    }

    public void Bookmarked()
    {
        string path = Application.persistentDataPath + "/BookmarkWord.txt";
        if (BookmarkBtn.btnBookmark.GetComponent<Image>().sprite == BookmarkBtn.Bookmarks)
        {
            File.AppendAllText(path, BookmarkBtn.CurrentVocabularyBtnClickedName + ";");

            string Imagepath = Application.persistentDataPath + BookmarkBtn.CurrentVocabularyBtnClickedName + "_image.txt";
            string Audiopath = Application.persistentDataPath + BookmarkBtn.CurrentVocabularyBtnClickedName + "_audio.txt";

            if (Connection.IsConnected)
            {
                form.AddField("user", PlayerPrefs.GetString("usernameKey").ToString());
                form.AddField("vocabularyPost", BookmarkBtn.CurrentVocabularyBtnClickedName);
                update = new WWW("http://10.254.253.91/bookmark.php", form);

                if (!File.Exists(Imagepath) && !File.Exists(Audiopath))
                {
                    StartCoroutine(FetchImage(Imagepath));
                    StartCoroutine(FetchAudio(Audiopath));
                }
            }
            BookmarkBtn.btnBookmark.GetComponent<Image>().sprite = BookmarkBtn.Unbookmark;
        }
        else
        {
            word.Remove(BookmarkBtn.CurrentVocabularyBtnClickedName);
            File.WriteAllText(path, "");

            for(int i=0; i<BookmarkBtn.Word.Length; i++)
            {
                File.AppendAllText(path, BookmarkBtn.Word[i]);
            }

            if (Connection.IsConnected)
            {
                form.AddField("user", PlayerPrefs.GetString("usernameKey").ToString());
                form.AddField("vocabularyPost", BookmarkBtn.CurrentVocabularyBtnClickedName);
                update = new WWW("http://10.254.253.91/Deletebookmark.php", form);
            }
            BookmarkBtn.btnBookmark.GetComponent<Image>().sprite = BookmarkBtn.Bookmarks;
        }
    }

    IEnumerator FetchImage(string path)
    {
        form.AddField("word", BookmarkBtn.CurrentVocabularyBtnClicked.name);
        form.AddField("scene", SceneManager.GetActiveScene().name);
        update = new WWW("http://192.168.7.92/FetchImage.php", form);
        yield return update;

        //byte[] Bytes = System.Convert.FromBase64String(update.text);
        byte[] Bytes = update.bytes;
        File.WriteAllBytes(path, Bytes);
    }

    IEnumerator FetchAudio(string path)
    {
        form.AddField("word", BookmarkBtn.CurrentVocabularyBtnClicked.name);
        form.AddField("scene", SceneManager.GetActiveScene().name);
        update = new WWW("http://192.168.7.92/FetchAudio.php", form);
        yield return update;

        //byte[] Bytes = System.Convert.FromBase64String(update.text);
        byte[] Bytes = update.bytes;
        File.WriteAllBytes(path, Bytes);
    }
}*/
