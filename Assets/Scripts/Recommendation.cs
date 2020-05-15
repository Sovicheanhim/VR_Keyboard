using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recommendation : MonoBehaviour
{
    string giantstring;
    string[] scenes, scene_id, scene_name;
    IEnumerator Start()
    {
        WWW texts = new WWW("http://192.168.7.92/readTempScene.php");
        yield return texts;
        giantstring = texts.text;
        scenes = giantstring.Split(';');
        for(int i = 0; i < scenes.Length - 1; i++)
        {

            scene_id[i] = scenes[i].Substring(scenes[i].IndexOf("Scene_ID") + 9);
            scene_id[i] = scene_id[i].Remove(scene_id[i].IndexOf("|"));
            scene_name[i] = scenes[i].Substring(scenes[i].IndexOf("Scene_Name") + 11);
            scene_name[i] = scene_name[i].Remove(scene_name[i].IndexOf("|"));
        }
    }

}
