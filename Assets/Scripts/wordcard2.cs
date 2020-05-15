// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class wordcard : MonoBehaviour
// {   
//     public Button butImage;

//     IEnumerator gettingQuations(){
//         imageString = "";
//         viewImageBool = false;
//         WWWForm form2 = new WWWForm();
//         form2.AddField("mapIDPost", mapSelect);
//         WWW www2;
//     }

//    IEnumerator GetImage()
//    {
//        WWWForm imageForm = new WWWForm();
//        imageForm.AddField("QuestioniImagePost", questionID[rndQuestion]);
//        WWW wwwImage = new WWW("http://10.254.253.91/wordcard/wordcard.php", imageForm);
//        yield return wwwImage;
//        imageString = (wwwImage.text);

//        if (imageString.Length > 100){
//            butImage.gameObject.SetActive(true);
//        }else{
//            butImage.gameObject.SetActive(false);
//        }
//    }
//    void OnGUI(){
//        if (viewImageBool == true){
//            byte[] Bytes = System.Convert.FromBase64String(imageString);
//            Texture2D texture = new Texture2D(1,1);
//            texture.LoadImage(Bytes);
//            OnGUI.DrawTexture(new Rect (200, 20, 440, 440), texture, ScaleMomde.ScaleToFit, true,if);
//        }
//    }

//    public void ViewImage(){
//        viewImageBool = true;
//        CloseImageWindow.SetActive(true);
//    }
//    public void CloseImage(){
//        viewImageBool = false;
//        CloseImageWindow.SetActive(false);
//    }
    
    
 
// }
