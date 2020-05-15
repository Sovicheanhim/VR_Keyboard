using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FetchVocabulary : MonoBehaviour
{
    public Text vocabulary;
    string BtnName = "";
    public GameObject OptionBtn;
    public GameObject BtnCollection;
    public GameObject ControlCollection;
    public GameObject Detail;
    public RawImage VocabularyImage;
 

    string RawString;

    public string[] AddedData;

    public string[] Word = new string[100];
    public string[] ImageString = new string[100];
    public string[] AudioString = new string[100];
    public string[] WordBookmark = new string[100];

    public GameObject var_card;


    [System.Obsolete]
    IEnumerator Start()
    {

        WWW words = new WWW("http://10.254.253.91/readVocabulary.php");
        yield return words;

        RawString = words.text;
        Debug.Log(RawString);

        AddedData = RawString.Split(';');

        for (int i = 0; i < AddedData.Length - 1; i++)
        {
            Word[i] = AddedData[i].Substring(AddedData[i].IndexOf('W') + 5);
            Word[i] = Word[i].Remove(Word[i].IndexOf('|'));

            WordBookmark[i] = AddedData[i].Substring(AddedData[i].IndexOf('B') + 9);
            WordBookmark[i] = WordBookmark[i].Remove(WordBookmark[i].IndexOf('|'));

            ImageString[i] = AddedData[i].Substring(AddedData[i].IndexOf("Image") + 6);
            ImageString[i] = ImageString[i].Remove(ImageString[i].IndexOf('|'));

            AudioString[i] = AddedData[i].Substring(AddedData[i].IndexOf("Audio") + 6);
        }
        ReturnBack();
    }

    public void ShowDefinitionBtn()
    {
        OptionBtn = EventSystem.current.currentSelectedGameObject;

        BtnCollection.SetActive(false);

        ControlCollection.transform.position = new Vector3(OptionBtn.transform.position.x - 19, (OptionBtn.transform.position.y - 15), OptionBtn.transform.position.z);
        ControlCollection.SetActive(true);
    }


    public void ReturnBack()
    {
        BtnCollection.SetActive(true);
        ControlCollection.SetActive(false);
        Detail.SetActive(false);
        OptionBtn = null;
    }

    public void ShowDetail()
    {
        BtnName = OptionBtn.name;
        Detail.transform.position = new Vector3(ControlCollection.transform.position.x, ControlCollection.transform.position.y + 40, ControlCollection.transform.position.z);
        //BtnName = EventSystem.current.currentSelectedGameObject.name;
        for (int i = 0; i < AddedData.Length - 1; i++)
        {
            if (Word[i] == BtnName)
            {
                vocabulary.text = Word[i];
                byte[] Bytes = System.Convert.FromBase64String(ImageString[i]);
                Texture2D texture = new Texture2D(100, 100);
                texture.LoadImage(Bytes);
                texture.Apply();
                VocabularyImage.GetComponent<RawImage>().texture = texture;

                Detail.SetActive(true);
                break;
            }
            else
            {
                //Detail.SetActive(true);
                continue;
            }
        }
    }
}