using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class visualScriptCIty : MonoBehaviour
{
    public GameObject GFX, details;
    Vector3 scaleChange;
    bool mouseOn;
    public static bool detailsOpen;
    void Start()
    {
        scaleChange = new Vector3 (0.1f, 0.1f, 0.1f);
    }
    void OnMouseOver()
    {
        if(!mouseOn)
            {
                GFX.transform.localScale +=scaleChange;
                mouseOn = true;
            }

        if(Input.GetMouseButtonDown(1) && !visualScriptCIty.detailsOpen)
        {
            details.SetActive(true);
            detailsOpen = true;
        }
    }
    void OnMouseExit()
    {
        if(mouseOn)
            {
                GFX.transform.localScale -=scaleChange;
                mouseOn = false;
            }
    }

    public void Close()
    {
        details.SetActive(false);
        detailsOpen = false;
    }
}
