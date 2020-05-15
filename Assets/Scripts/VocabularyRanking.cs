using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VocabularyRanking : MonoBehaviour
{
    public string currentVocabulay, giantString;
    public string[] registeredVocabularies;
    public string[] vocabularies = new string[10000];
    public string[] clicks = new string[10000];
    public int currentID, currentClick;

    IEnumerator Start()
    {
        WWW vocabs = new WWW("https://10.254.253.91/readVocabulary.php");
        yield return vocabs;
        giantString = vocabs.text;
        registeredVocabularies = giantString.Split(';');
        for (int i = 0; i < registeredVocabularies.Length - 1; i++) {
            clicks[i] = registeredVocabularies[i].Substring(registeredVocabularies[i].IndexOf("Click")+1);
            vocabularies[i] = registeredVocabularies[i].Substring(registeredVocabularies[i].IndexOf("W") + 5);
            vocabularies[i] = vocabularies[i].Remove(vocabularies[i].IndexOf("|"));
        }

    }

    public void ReceiveVocab(string currentVocabulary) {
        this.currentVocabulay = currentVocabulary;
        UpdateClick();
    }

    public void UpdateClick()
    {
        for (int i = 0; i < vocabularies.Length - 1; i++)
        {
            if (currentVocabulay == vocabularies[i])
            {
                currentID = i;
            }
        }
        currentClick = Convert.ToInt32(clicks[currentID]) + 1;
        sendClick(currentClick, vocabularies[currentID]);
        Debug.Log(currentClick+ vocabularies[currentID]);
    }

    public void sendClick(int click, string vocabulary) {
        WWWForm form = new WWWForm();
        form.AddField("clickPost", click);
        form.AddField("vocabularyPost", vocabulary);

        WWW register = new WWW("http://10.254.253.91/updatePassword.php", form);
    }
}
