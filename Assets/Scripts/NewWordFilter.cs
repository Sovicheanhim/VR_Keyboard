using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewWordFilter : MonoBehaviour
{
    string giantString;
    string[] ids = new string[1000];
    string[] vocabularies = new string[10000];
    string[] understoodVocabularies = new string[10000];
    string[] registeredVocabulaires;
    public int currentID;
    IEnumerator Start()
    {
        WWW vocabs = new WWW("https://10.254.253.91/readVocabulary.php");
        yield return vocabs;
        registeredVocabulaires = giantString.Split(';');
        for (int i = 0; i < registeredVocabulaires.Length - 1; i++)
        {
            vocabularies[i] = registeredVocabulaires[i].Substring(registeredVocabulaires[i].IndexOf("Word") + 5);
            vocabularies[i] = vocabularies[i].Remove(vocabularies[i].IndexOf("|"));
            ids[i] = registeredVocabulaires[i].Substring(registeredVocabulaires[i].IndexOf("ID") + 3);
            ids[i] = ids[i].Remove(ids[i].IndexOf("|"));
        }
    }

    public void CheckIfUnderstood()
    {

    }
}
