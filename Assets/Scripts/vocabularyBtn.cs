using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class vocabularyBtn : MonoBehaviour
{
    public GameObject varSettingExpand;
    public GameObject varQuizComingSoon;
    public GameObject VarIQComingSoon;

    // Start is called before the first frame update
    void Start()
    {
        varSettingExpand.SetActive(false);
        varQuizComingSoon.SetActive(false);
        VarIQComingSoon.SetActive(false);
    }

    // Update is called once per frame
 
    public void vocabularyButton(){
        SceneManager.LoadScene("ListRoom");
    }
    public void settingBtn(){
        varSettingExpand.SetActive(true);
    }
    public void showQuizComingSoon(){
        varQuizComingSoon.SetActive(true);
    }
    public void showIQComingSoon(){
        VarIQComingSoon.SetActive(true);
    }
}
