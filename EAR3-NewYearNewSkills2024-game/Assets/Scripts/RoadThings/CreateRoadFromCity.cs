using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateRoadFromCity : MonoBehaviour
{
    public GameObject gameManager;
    bool mouseOver;
    GameObject currentRoadManager;
    public GameObject roadBluePrint, sunetGO;

    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager");
    }

    void OnMouseOver()
    {
        Debug.Log("Mouse over" + gameObject.name);
        mouseOver=true;
    }

    void OnMouseExit()
    {
        Debug.Log("Mouse exit");
        mouseOver=false;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(mouseOver && SceneManager.GetActiveScene().name != "Main Menu")
            {
                if(gameManager.GetComponent<MainMenuScript>().inGameMenu.activeSelf == false)
                {
                    Invoke("SetStartPos", 0.001f);
                    GameObject roadBP = Instantiate(roadBluePrint, transform.position, Quaternion.identity);
                    roadBP.GetComponent<LineRenderer>().SetPosition(0, this.transform.position);
                }
            }
            else if(mouseOver)
            {
                Invoke("SetStartPos", 0.001f);
                GameObject roadBP = Instantiate(roadBluePrint, transform.position, Quaternion.identity);
                roadBP.GetComponent<LineRenderer>().SetPosition(0, this.transform.position);
            }
        }

        if(Input.GetMouseButtonUp(0))
        {
            if(mouseOver)
            {
                SetEndPos();
                Instantiate(sunetGO);
            }
        }
    }

    void SetStartPos()
    {
        gameManager.GetComponent<SpawnRoadManager>().canBuildRoad=true;
        if(SceneManager.GetActiveScene().name != "Main Menu")
        {
            for(int i=3;i<gameManager.transform.childCount;i++)
            {
                if(gameManager.transform.GetChild(i).gameObject.GetComponent<RoadManager>().isNew) 
                {
                    currentRoadManager = gameManager.transform.GetChild(i).gameObject;
                    gameManager.transform.GetChild(i).gameObject.GetComponent<RoadManager>().startPos = this.gameObject.transform.position;
                }
            }
        }
        else
        {
            for(int i=0;i<gameManager.transform.childCount;i++)
            {
                if(gameManager.transform.GetChild(i).gameObject.GetComponent<RoadManager>().isNew) 
                {
                    currentRoadManager = gameManager.transform.GetChild(i).gameObject;
                    gameManager.transform.GetChild(i).gameObject.GetComponent<RoadManager>().startPos = this.gameObject.transform.position;
                }
            }
        }
    }

    void SetEndPos()
    {
        if(SceneManager.GetActiveScene().name != "Main Menu")
        {
            for(int i=3;i<gameManager.transform.childCount;i++)
            {
                if(gameManager.transform.GetChild(i).gameObject.GetComponent<RoadManager>().isNew) 
                {
                    currentRoadManager = gameManager.transform.GetChild(i).gameObject;
                    gameManager.transform.GetChild(i).gameObject.GetComponent<RoadManager>().endPos = this.gameObject.transform.position;
                    currentRoadManager.GetComponent<RoadManager>().finishRoad=true;
                }
            }
        }
        else
        {
            for(int i=0;i<gameManager.transform.childCount;i++)
            {
                if(gameManager.transform.GetChild(i).gameObject.GetComponent<RoadManager>().isNew) 
                {
                    currentRoadManager = gameManager.transform.GetChild(i).gameObject;
                    gameManager.transform.GetChild(i).gameObject.GetComponent<RoadManager>().endPos = this.gameObject.transform.position;
                    currentRoadManager.GetComponent<RoadManager>().finishRoad=true;
                }
            }
        }
    }
}
