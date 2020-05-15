using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FetchDataofVocabulary : MonoBehaviour
{
    public GameObject collection;
    string RawString;

    public string[] AddedData;

    public string[] Word = new string[100];
    public string[] ImageString = new string[100];
    public string[] AudioString = new string[100];
    public string[] WordBookmark = new string[100];
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
        if (SceneManager.GetActiveScene().name == "card")
        {
            CardCreator[] cards = collection.transform.gameObject.GetComponentsInChildren<CardCreator>();
            foreach (CardCreator card in cards)
            {
                card.fetch();
            }
        }

    }

    public void backBtn(){
        SceneManager.LoadScene("ListRoom");
    }
}
