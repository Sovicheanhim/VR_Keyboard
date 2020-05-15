using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerScript : MonoBehaviour
{
    public GameObject SelectedObject;
    // Start is called before the first frame update
    void Start()
    {
        SelectedObject = new GameObject();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if(Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if(hit.collider != null)
            {
                if(SelectedObject != hit.collider.gameObject)
                {
                    SelectedObject = hit.transform.gameObject;
                }
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
                {
                    SelectedObject.transform.SendMessage("OnBtnVocabularyClicked");
                }
            }
        }
        else
        {
            if(SelectedObject != null)
            {
                SelectedObject = new GameObject();
            }
        }
    }
}
