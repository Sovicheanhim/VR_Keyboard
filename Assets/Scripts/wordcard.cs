using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wordcard : MonoBehaviour
{   
    //question data table
    static int arr = 10;
    public string[] itemQuestionData;
    public string[] title = new string[arr];
    public string[] tag1 = new string[arr];
    //wordcard data table
    public string[] itemWordcarddata;
    public string[] image = new string[arr];
    public string[] audio = new string[arr];
    public string[] tag2 = new string[arr];
    public string[] label = new string[arr];

    public GameObject var_cardA;

    string my_status;
    string my_image1, my_title1;
    string my_image2, my_title2;
    string my_image3, my_title3;
    string my_image4, my_title4;
    string my_image5, my_title5;
    // public GameObject var_cardB;
    
   IEnumerator Start()
    {
        WWW questiondata = new WWW("http://10.254.253.91/wordcard/questiondata.php");
        WWW wordcarddata = new WWW("http://10.254.253.91/wordcard/wordcarddata.php");
        yield return questiondata;
        yield return wordcarddata;
        string questiondataString = questiondata.text;
        string wordcarddataString = wordcarddata.text;
        itemQuestionData = questiondataString.Split(';');
        itemWordcarddata = wordcarddataString.Split(';');
        // print(GetDataValue(itemQuestionData[0], "title:"));
        for(int i= 0; i < itemQuestionData.Length -1; i++){
            title[i] = itemQuestionData[i].Substring(itemQuestionData[i].IndexOf("title") + 6);
            title[i] = title[i].Remove(title[i].IndexOf("|"));
            tag1[i] = itemQuestionData[i].Substring(itemQuestionData[i].IndexOf("tag")+4);
        }
        for(int j= 0; j < itemWordcarddata.Length -1; j++){
            label[j] = itemWordcarddata[j].Substring(itemWordcarddata[j].IndexOf("title")+6);
            label[j] = label[j].Remove(label[j].IndexOf("|"));
            image[j] = itemWordcarddata[j].Substring(itemWordcarddata[j].IndexOf("image") + 6);
            image[j] = image[j].Remove(image[j].IndexOf("|"));
            audio[j] = itemWordcarddata[j].Substring(itemWordcarddata[j].IndexOf("audio") + 6);
            audio[j] = audio[j].Remove(audio[j].IndexOf("|"));
            tag2[j] = itemWordcarddata[j].Substring(itemWordcarddata[j].IndexOf("tag")+4);
        }
        
        
        for(int k= 0; k < itemQuestionData.Length -1; k++){
            if (tag1[k] == tag2[k]){

                my_status = title[k];

                my_title1 = label[k];
                my_image1 = image[k];

                my_title2 = label[k+1];
                my_image2 = image[k+1];

                my_title3 = label[k+2];
                my_image3 = image[k+2];

                my_title4 = label[k+3];
                my_image4 = image[k+3];

                my_title5 = label[k+4];
                my_image5 = image[k+4];
                
                break;
            }
        }
        // Debug.Log("Hello");
        // for(int s = 0; s < 4; s++){
        //     if (tag1[s] == tag2[s]){

        //     }
        // }
        allCard();


        
    }
  

    public void allCard(){
            var number1 = Random.Range(1,5);
            var number2 = Random.Range(1,5);
            var number3 = Random.Range(1,5);
            var number4 = Random.Range(1,5);


            GameObject newCardA = Instantiate<GameObject>(var_cardA, transform);
            newCardA.transform.Find("status").gameObject.GetComponent<Text>().text = my_status;
            
            newCardA.transform.Find("Text"+number1+"").gameObject.GetComponent<Text>().text = my_title1;
            byte[] Bytes = System.Convert.FromBase64String(my_image1);
            Texture2D texture = new Texture2D(200, 200);
            texture.LoadImage(Bytes);
            texture.Apply();
            newCardA.transform.Find("RawImage"+number1+"").gameObject.GetComponent<RawImage>().texture = texture;

            newCardA.transform.Find("Text"+number2+"").gameObject.GetComponent<Text>().text = my_title2;
            byte[] BBytes = System.Convert.FromBase64String(my_image2);
            Texture2D Btexture = new Texture2D(200, 200);
            Btexture.LoadImage(BBytes);
            Btexture.Apply();
            newCardA.transform.Find("RawImage"+number2+"").gameObject.GetComponent<RawImage>().texture = Btexture;

            newCardA.transform.Find("Text"+number3+"").gameObject.GetComponent<Text>().text = my_title3;
            byte[] CBytes = System.Convert.FromBase64String(my_image3);
            Texture2D Ctexture = new Texture2D(200, 200);
            Ctexture.LoadImage(CBytes);
            Ctexture.Apply();
            newCardA.transform.Find("RawImage"+number3+"").gameObject.GetComponent<RawImage>().texture = Ctexture;

            newCardA.transform.Find("Text"+number4+"").gameObject.GetComponent<Text>().text = my_title4;
            byte[] DBytes = System.Convert.FromBase64String(my_image4);
            Texture2D Dtexture = new Texture2D(200, 200);
            Dtexture.LoadImage(DBytes);
            Dtexture.Apply();
            newCardA.transform.Find("RawImage"+number4+"").gameObject.GetComponent<RawImage>().texture = Dtexture;
        }

        

    
 
}
