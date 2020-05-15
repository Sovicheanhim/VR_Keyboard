using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OculusController : MonoBehaviour
{
    string scene_name = "";
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.Back))
        {
            scene_name = SceneManager.GetActiveScene().name;
            switch(scene_name)
            {
                case "Sign_Up":
                    SceneManager.LoadScene("Log_In");
                    break;
                case "Setting":
                    SceneManager.LoadScene("MainScene");
                    break;
                case "ChangePassword":
                    SceneManager.LoadScene("Setting");
                    break;
                case "Test":
                    SceneManager.LoadScene("MainScene");
                    break;
                case "Completed":
                    SceneManager.LoadScene("MainScene");
                    break;
                case "MainScene":
                    SceneManager.LoadScene("Log_In");
                    break;
                case "Recommend":
                    SceneManager.LoadScene("MainScene");
                    break;
                default:
                    SceneManager.LoadScene("MainScene");
                    break;
            }
                

        }
    }
}
