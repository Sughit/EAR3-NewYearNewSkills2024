using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CloseDetailsForTutorial : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject details;
    bool mouseOver;


    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        Debug.Log("Pointer enter");
        mouseOver=true;
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        Debug.Log("Pointer exit");
        mouseOver=false;
    }

    public void SetMouseOver()
    {
        Debug.Log("Pointer changes");
        if(mouseOver) mouseOver=false;
        else mouseOver=true;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(mouseOver)
            {
                details.SetActive(false);
            }
        }
    }
}
