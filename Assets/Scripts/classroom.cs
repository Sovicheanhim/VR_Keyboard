using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class classroom : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
  
   public void HomeBtnFunc(){
        SceneManager.LoadScene("FirstScene");
    }
   public void MainsceneHome(){
        SceneManager.LoadScene("Mainscene");
    }
    public void classroomBtn(){
    SceneManager.LoadScene("Detail");
    }
    public void bedroomBtn()  { 
        SceneManager.LoadScene("livingroom");
    }
    public void auditoriumBtn()  { 
        SceneManager.LoadScene("auditorium");
    }
}
