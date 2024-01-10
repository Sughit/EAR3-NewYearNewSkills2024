using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class visualScriptCIty : MonoBehaviour
{
    public GameObject GFX, details;
    Vector3 scaleChange;
    bool mouseOn;
    public static bool detailsOpen;
    public Text cityName;
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

        if(Input.GetMouseButtonDown(1))
            StartCoroutine(Over());
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
        CloseCityCanvas.open = false;
    }
    IEnumerator Over()
    {
        CloseCityCanvas.open = false;
        yield return new WaitForSeconds(0.01f);
        CloseCityCanvas.open = true;
        details.SetActive(true);
    }
}
