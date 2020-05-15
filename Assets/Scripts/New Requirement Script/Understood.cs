using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Understood : MonoBehaviour
{
    CheckInternetConnection Connection;
    public ShowControlButton buttonClicked;
    public FetchDataFromSence Arr_word;
    public PronunciationFunction Word;

    string word;
    public List<string> wordlist = new List<string>();
    public int und_percentage;

    public Texture correct;
    WWWForm form;

    void Start()
    {
        form = new WWWForm();
        wordlist.AddRange(Arr_word.Word);

        Connection = GameObject.Find("InternetManager").GetComponent<CheckInternetConnection>();
        Word = GameObject.Find("Script Manager").GetComponent<PronunciationFunction>();
    }

    public void comparePronunciation()
    {
        if(Word.SpeechText.text.TrimEnd() == buttonClicked.CurrentVocabularyBtnClickedName.ToLower())
        {
            buttonClicked.CurrentVocabularyBtnClicked.GetComponent<RawImage>().texture = correct;
            buttonClicked.Default();

            form.AddField("userName", PlayerPrefs.GetString("usernameKey").ToString());
            form.AddField("vocabularyPost", buttonClicked.CurrentVocabularyBtnClickedName);
            WWW update = new WWW("http://192.168.7.92/already_understandy.php", form);
            update = new WWW("http://192.168.7.92/recommendNewScenes.php", form);

            wordlist.Remove(word);
        }
    }

    public void BackFromScene()
    {
        if(Connection.IsConnected)
        {
            WWW update;
            und_percentage = Arr_word.Word.Length - ((wordlist.Count * 100) / Arr_word.Word.Length);
            string scene_name = SceneManager.GetActiveScene().name;

            form.AddField("userName", PlayerPrefs.GetString("usernameKey").ToString());
            form.AddField("sceneNamePost", scene_name);
            form.AddField("percentagePost", und_percentage);
            update = new WWW("http://192.168.7.92/update_percentage.php", form);

            StartCoroutine(RecommendScene());
        }
        else
        {
            SceneManager.LoadScene("Recommend");
        }
        string sceneName = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetString("incompleteScene", sceneName);
    }

    IEnumerator RecommendScene()
    {
        Arr_word.loading.SetActive(true);
        form.AddField("userName", PlayerPrefs.GetString("usernameKey").ToString());
        WWW update = new WWW("http://192.168.7.92/recommendNewScenes.php", form);
        yield return update;
        string status = update.text.TrimEnd();

        if(status == "DONE")
        {
            Arr_word.loading.SetActive(false);
            SceneManager.LoadScene("Recommend");
        }
    }
}
