using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class VocabularyCard : MonoBehaviour
{
    public GameObject VocabularyCardCanvas;
    public Text WordText, StatusText;
    public RawImage VocabularyImage;
    public AudioSource audio;

    public ShowControlButton ControlBtn;
    public FetchDataFromSence VocabData;
    public Understood understood;

    public int i,WordID;
    byte[] Bytes;
    CheckInternetConnection Connection;
    WWWForm form;
    WWW www;

    void Start()
    {
        form = new WWWForm();
        form.AddField("userName", PlayerPrefs.GetString("usernameKey").ToString());

        //Connection = GameObject.Find("InternetManager").GetComponent<CheckInternetConnection>();
        string path = Application.persistentDataPath + "/" + ControlBtn.CurrentVocabularyBtnClickedName + "_photo.txt";
        StartCoroutine(FetchImage(path));
    }

    public void OnDetailBtnClicked()
    {
        VocabularyImage.GetComponent<RawImage>().texture = null;

        WordText.text = ControlBtn.CurrentVocabularyBtnClickedName;

        VocabularyCardCanvas.SetActive(true);

        string path = Application.persistentDataPath + "/" + ControlBtn.CurrentVocabularyBtnClickedName + "_photo.txt";

        if (Connection.IsConnected)
        { 
            if (!File.Exists(path))
            {
                StartCoroutine(FetchImage(path));
            }
            else
            {
                Bytes = GetImage(path);

                Texture2D texture = new Texture2D(100, 100);
                texture.LoadImage(Bytes);
                texture.Apply();
                VocabularyImage.GetComponent<RawImage>().texture = texture;
            }
        }
        else
        {
            if (!File.Exists(path))
            {
                StatusText.text = "No Internet Connection";
            }
            else
            {
                Bytes = GetImage(path);

                Texture2D texture = new Texture2D(100, 100);
                texture.LoadImage(Bytes);
                texture.Apply();
                VocabularyImage.GetComponent<RawImage>().texture = texture;
            }
        }        
    }
    public void OnBtnAudioClicked()
    {
        string path = Application.persistentDataPath + "/" + ControlBtn.CurrentVocabularyBtnClickedName + "_audio.txt";

        if (Connection.IsConnected)
        {
            if (!File.Exists(path))
            {
                StartCoroutine(FetchAudio(path));
            }
            else
            {
                Bytes = GetAudio(path);

                Wav wav = new Wav(Bytes);
                AudioClip audioClip = AudioClip.Create("testSound", wav.SampleCount, 1, wav.Frequency, false, false);
                audioClip.SetData(wav.LeftChannel, 0);
                audio.clip = audioClip;
                audio.Play();
            }
        }
        else
        {
            if (!File.Exists(path))
            {
                StatusText.text = "No Internet Connection";
            }
            else
            {
                Bytes = GetAudio(path);

                Wav wav = new Wav(Bytes);
                AudioClip audioClip = AudioClip.Create("testSound", wav.SampleCount, 1, wav.Frequency, false, false);
                audioClip.SetData(wav.LeftChannel, 0);
                audio.clip = audioClip;
                audio.Play();
            }
        }
    }

    IEnumerator FetchImage(string path)
    {
        StatusText.text = "Loading...";

        //form.AddField("word", ControlBtn.CurrentVocabularyBtnClicked.name);
        //form.AddField("scene", SceneManager.GetActiveScene().name);
        //www = new WWW("http://192.168.7.92/FetchImage.php", form);
        www = new WWW("http://192.168.7.92/FetchImage.php");
        yield return www;
        Debug.Log(www.text);

        Bytes = System.Convert.FromBase64String(www.text);
        //Bytes = www.bytes;
        File.WriteAllBytes(path, Bytes);

        Texture2D texture = new Texture2D(100, 100);
        texture.LoadImage(Bytes);
        texture.Apply();
        VocabularyImage.GetComponent<RawImage>().texture = texture;

        StatusText.text = "";
    }

    public byte[] GetImage(string path)
    {
        return File.ReadAllBytes(path);
    }

    IEnumerator FetchAudio(string path)
    {
        StatusText.text = "Loading...";

        form.AddField("word", ControlBtn.CurrentVocabularyBtnClicked.name);
        form.AddField("scene", SceneManager.GetActiveScene().name);
        www = new WWW("http://192.168.7.92/FetchAudio.php", form);
        yield return www;

        //Bytes = System.Convert.FromBase64String(www.text);
        Bytes = www.bytes;
        File.WriteAllBytes(path, Bytes);

        Wav wav = new Wav(Bytes);
        AudioClip audioClip = AudioClip.Create("testSound", wav.SampleCount, 1, wav.Frequency, false, false);
        audioClip.SetData(wav.LeftChannel, 0);
        audio.clip = audioClip;
        audio.Play();

        StatusText.text = "";
    }

    public byte[] GetAudio(string path)
    {
        return File.ReadAllBytes(path);
    }
    /*static int BinarySearch(string[] arr, int l, int r, int x){
        if (r >= 1){
            int mid = l + (r-l)/2;
            if(mid == x){
                return mid;
            }
            if(mid > x){
                return BinarySearch(arr, l, mid - 1, x);
            }
            return BinarySearch(arr, mid + 1, r, x);
        }
        return -1;
    }*/

}
