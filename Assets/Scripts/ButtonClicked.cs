using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClicked : MonoBehaviour
{
    public int count = 0;
    public Text textshowed;
    public InputField input;
    //public GameObject canvasKeyboard;
    


    public void changeWord(){
        if (count == 0){
            textshowed.text = "Hello";
            count = 1;
        }
        else{
            textshowed.text = "Bye";
            count = 0;
        }
        
    } 

    public void keyClicked(GameObject kb){
            string s;
            s = kb.name;
            SendKey(s);
    }

    public void SendKey(string keyString) {
        input.text += keyString;
    }

}
