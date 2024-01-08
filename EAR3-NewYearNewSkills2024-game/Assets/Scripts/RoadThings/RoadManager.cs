using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    LineRenderer lineRend;
    public Vector3 startPos;
    public Vector3 endPos;

    public bool finishRoad;
    public bool isNew=true;
    bool canDestroy=true;

    void Start()
    {
        lineRend = GetComponent<LineRenderer>();
        lineRend.positionCount = 2;
    }

    void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            if(finishRoad)
            {
                lineRend.SetPosition(0, startPos);
                lineRend.SetPosition(1, endPos);
                isNew=false;
                finishRoad=false;
                canDestroy=false;
                float distance = Vector3.Distance(startPos, endPos);
                if(GameObject.Find("GameManager").GetComponent<MoneyScript>().CalculateRoadCost(distance) > MoneyScript.money) 
                {
                    Debug.Log("Too expensive to build");
                    Destroy(this.gameObject);
                }
                else 
                {
                    GameObject.Find("GameManager").GetComponent<MoneyScript>().UpdateMoney(distance);
                    GameObject.Find("GameManager").GetComponent<CityManagement>().TryToAddCity(startPos, endPos);
                }
            }
            else if(canDestroy)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
