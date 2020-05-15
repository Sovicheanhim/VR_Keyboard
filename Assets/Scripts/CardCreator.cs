using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardCreator : MonoBehaviour
{
    public GameObject Card;
    public Text Vocabulary;
    public RawImage image;
    public AudioSource audio;

    public byte[] WavBytes;

    public FetchDataofVocabulary Vocabdata;

    int j;
    
    public void fetch()
    {
        for (j = 0; j < Vocabdata.AddedData.Length - 1; j++)
        {
            if (Card.name == Vocabdata.Word[j])
            {
                Vocabulary.text = Vocabdata.Word[j];

                byte[] Bytes = System.Convert.FromBase64String(Vocabdata.ImageString[j]);
                Texture2D texture = new Texture2D(100, 100);
                texture.LoadImage(Bytes);
                texture.Apply();
                image.GetComponent<RawImage>().texture = texture;

                break;
            }
        }
    }

    public void PlayAudio()
    {
        WavBytes = System.Convert.FromBase64String(Vocabdata.AudioString[j]);
        Wav wav = new Wav(WavBytes);
        AudioClip audioClip = AudioClip.Create("testSound", wav.SampleCount, 1, wav.Frequency, false, false);
        audioClip.SetData(wav.LeftChannel, 0);
        audio.clip = audioClip;
        audio.Play();
    }
}