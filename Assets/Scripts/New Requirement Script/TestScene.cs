using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TestScene : MonoBehaviour
{
    public GameObject VocabularyCardCanvas;
    public Text WordText, SpeechText, statusText;
    public RawImage VocabularyImage;
    public AudioSource audio;
    public GameObject loading;

    public ShowControlButton ControlBtn;
    public PronunciationFunction speech;
    private CheckInternetConnection Connection;

    public Texture correct;
    int res;
    string Imagepath, Audiopath;
    WWWForm form;

    void Start()
    {
        form = new WWWForm();

        Connection = GameObject.Find("InternetManager").GetComponent<CheckInternetConnection>();
    }

    public void OnDetailBtnClicked()
    {
        Imagepath = "Test Scene/Images/" + ControlBtn.CurrentVocabularyBtnClickedName;

        SpeechText.text = "";
        WordText.text = ControlBtn.CurrentVocabularyBtnClickedName;

        VocabularyImage.GetComponent<RawImage>().texture = Resources.Load(Imagepath) as Texture;

        VocabularyCardCanvas.SetActive(true);
    }

    public void OnBtnAudioClicked()
    {
        Audiopath = "Test Scene/Audio/" + ControlBtn.CurrentVocabularyBtnClickedName;

        AudioClip audioClip = (AudioClip)Resources.Load(Audiopath);
        audio.clip = audioClip;
        audio.Play();
    }

    void Update()
    {
        SpeechText.text = speech.Speech;
    }

    public void comparePronunciation()
    {
        if (WordText.text.ToLower() == SpeechText.text.TrimEnd())
        {
            ControlBtn.CurrentVocabularyBtnClicked.GetComponent<RawImage>().texture = correct;
            ControlBtn.Default();

            if (Connection.IsConnected)
            {
                form.AddField("userName", PlayerPrefs.GetString("usernameKey").ToString());
                form.AddField("vocabularyPost", ControlBtn.CurrentVocabularyBtnClickedName);
                WWW update = new WWW("http://192.168.7.92/already_understandy.php", form);
                StartCoroutine(RecommendScene());
            }
        }
    }

    public void BackFromScene()
    {
        if (Connection.IsConnected)
        {
            StartCoroutine(RecommendScene());
        }
        else
        {
            SceneManager.LoadScene("Recommend");
        }
    }

    IEnumerator RecommendScene()
    {
        loading.SetActive(true);
        form.AddField("userName", PlayerPrefs.GetString("usernameKey").ToString());
        WWW update = new WWW("http://192.168.7.92/recommendNewScenes.php", form);
        yield return update;
        string status = update.text.TrimEnd();

        if (status == "DONE")
        {
            loading.SetActive(false);
            SceneManager.LoadScene("Recommend");
        }
        else
        {
            statusText.text = "Error!!!!";
            SceneManager.LoadScene("Recommend");
        }
    }
}
