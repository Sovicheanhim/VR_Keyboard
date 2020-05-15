using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public AudioSource _audio;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator DownloadTheAudio(string objectName)
    {
        string url = "https://translate.google.com/translate_tts?ie=UTF-8&total=1&idx=0&textlen=32&client=tw-ob&q=" + objectName + "&tl=En-gb";
        WWW www = new WWW(url);
        yield return www;

        _audio.clip = www.GetAudioClip(false, true, AudioType.MPEG);
        _audio.Play();
        //Debug.Log("It's supposed to be playing");
    }

    public void PlayVoice(string objectName)
    {
        Debug.Log("Playing voice clicked");
        StartCoroutine(DownloadTheAudio(objectName));
    }

    public void PlayTable()
    {
        PlayVoice("Table");
    }
}
