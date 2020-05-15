using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(GameObject))]
public class HoverEnlarge : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private GameObject gameobject;
    private GameObject DetailBar;
    public GameObject BarPrefeb;

    void Start()
    {
        gameobject = GetComponent<GameObject>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("enter");
        transform.localScale += new Vector3(0.1f, 0.1f, 0.1f); //adjust these values as you see fit

        DetailBar = Instantiate<GameObject>(BarPrefeb, GameObject.Find("Canvas").transform);
        DetailBar.transform.position = new Vector3(transform.position.x, (transform.position.y - 85), transform.position.z);

        DetailBar.transform.Find("Text").gameObject.GetComponent<Text>().text = name;
    }


    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("left");
        transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);  // assuming you want it to return to its original size when your mouse leaves it.
        Destroy(DetailBar);
    }
}
