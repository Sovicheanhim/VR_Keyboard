using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle_setting : MonoBehaviour
{
    public GameObject SettingButton;

    void Start(){
        SettingButton.SetActive(false);
    }
    public void ToggleSettingFunc(){
        if (SettingButton != null){
            bool isActive = SettingButton.activeSelf;
            SettingButton.SetActive(!isActive);
        }
    }
}
