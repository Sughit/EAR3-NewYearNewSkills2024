using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRoadFromCity : MonoBehaviour
{
    public GameObject gameManager;
    bool mouseOver;
    GameObject currentRoadManager;

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
            if(mouseOver)
            {
                Invoke("SetStartPos", 0.001f);
            }
        }

        if(Input.GetMouseButtonUp(0))
        {
            if(mouseOver)
            {
                SetEndPos();
            }
        }
    }

    void SetStartPos()
    {
        gameManager.GetComponent<SpawnRoadManager>().canBuildRoad=true;
        for(int i=0;i<gameManager.transform.childCount;i++)
        {
            if(gameManager.transform.GetChild(i).gameObject.GetComponent<RoadManager>().isNew) 
            {
                currentRoadManager = gameManager.transform.GetChild(i).gameObject;
                gameManager.transform.GetChild(i).gameObject.GetComponent<RoadManager>().startPos = this.gameObject.transform.position;
            }
        }
    }

    void SetEndPos()
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
