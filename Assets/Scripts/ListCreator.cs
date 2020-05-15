using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListCreator : MonoBehaviour
{
    /*public ScrollRect ScrollView;
    public GameObject ScrollContent;
    public GameObject ScrollItemPrefeb;*/

    /*public Transform SpawnPoint = null;
    public GameObject item = null;
    public RectTransform content = null;*/

    public GameObject itemPrefab;

    string RawString;

    public string[] AddedData;

    public string[] Word = new string[100];
    public string[] ImageString = new string[100];
    public string[] AudioString = new string[100];
    [System.Obsolete]
    IEnumerator Start()
    {
        WWW words = new WWW("http://10.254.253.91/readBookmark.php");
        yield return words;

        RawString = words.text;
        Debug.Log(RawString);

        AddedData = RawString.Split(';');

        for (int i = 0; i < AddedData.Length - 1; i++)
        {
            Word[i] = AddedData[i].Substring(AddedData[i].IndexOf('W') + 5);
            Word[i] = Word[i].Remove(Word[i].IndexOf('|'));

            ImageString[i] = AddedData[i].Substring(AddedData[i].IndexOf("Image") + 6);
            ImageString[i] = ImageString[i].Remove(ImageString[i].IndexOf('|'));

            AudioString[i] = AddedData[i].Substring(AddedData[i].IndexOf("Audio") + 6);
        }
        //ScrollView.verticalNormalizedPosition = 1;

        for (int j = 0; j < AddedData.Length-1; j++)
        {
            GameObject newitems = Instantiate<GameObject>(itemPrefab, transform);
            newitems.transform.Find("Text").gameObject.GetComponent<Text>().text = Word[j];
            byte[] Bytes = System.Convert.FromBase64String(ImageString[j]);
            Texture2D texture = new Texture2D(200, 200);
            texture.LoadImage(Bytes);
            texture.Apply();
            newitems.transform.Find("VocabularyImage").gameObject.GetComponent<RawImage>().texture = texture;


            /*GameObject scrollObjItems = Instantiate(ScrollItemPrefeb);
    
            scrollObjItems.transform.SetParent(ScrollContent.transform, false);

            scrollObjItems.transform.Find("Text").gameObject.GetComponent<Text>().text = Word[j];

            byte[] Bytes = System.Convert.FromBase64String(ImageString[j]);
            Texture2D texture = new Texture2D(200, 200);
            texture.LoadImage(Bytes);
            texture.Apply();
            scrollObjItems.transform.Find("VocabularyImage").gameObject.GetComponent<RawImage>().texture = texture;*/
            /*float spawnY = j * 60;
            Vector3 pos = new Vector3(SpawnPoint.position.x, -spawnY, SpawnPoint.position.z);
            GameObject SpawnedItem = Instantiate(item, pos, SpawnPoint.rotation);
            SpawnedItem.transform.SetParent(SpawnPoint, false);
            ItemsList itemslist = SpawnedItem.GetComponent<ItemsList>();

            itemslist.word.text = Word[j];

            byte[] Bytes = System.Convert.FromBase64String(ImageString[j]);
            Texture2D texture = new Texture2D(200, 200);
            texture.LoadImage(Bytes);
            texture.Apply();
            itemslist.image.texture = texture;*/
        }
    }
}
