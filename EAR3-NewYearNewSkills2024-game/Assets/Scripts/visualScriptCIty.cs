using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
            if(SceneManager.GetActiveScene().name != "Main Menu")
            {
                if(GameObject.FindWithTag("GameManager").GetComponent<MainMenuScript>().inGameMenu.activeSelf == false)
                {
                    GFX.transform.localScale +=scaleChange;
                    mouseOn = true;
                }
            }
            else
            {
                GFX.transform.localScale +=scaleChange;
                mouseOn = true;
            }
        }

        if(Input.GetMouseButtonDown(1) && SceneManager.GetActiveScene().name != "Main Menu")
        {
            if(GameObject.FindWithTag("GameManager").GetComponent<MainMenuScript>().inGameMenu.activeSelf == false) StartCoroutine(Over());
        }
        else if(Input.GetMouseButtonDown(1))
        {
            StartCoroutine(Over());
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
        Debug.Log("Trebuie inchis");
        details.SetActive(false);
        CloseCityCanvas.open = false;
    }
    IEnumerator Over()
    {
        CloseCityCanvas.open = false;
        yield return new WaitForSeconds(0.01f);
        CloseCityCanvas.open = true;
        if(details != null) details.SetActive(true);
    }
}
