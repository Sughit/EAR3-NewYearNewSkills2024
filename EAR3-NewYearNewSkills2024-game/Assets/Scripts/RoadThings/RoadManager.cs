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

    public List<Vector3> pair = new List<Vector3>();

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
                    pair.Add(startPos);
                    pair.Add(endPos);
                    if(!SeeIfCanBuildRoad()) Destroy(this.gameObject);
                    else
                    {
                        GameObject.Find("GameManager").GetComponent<SpawnRoadManager>().roads.Add(this);
                        GameObject.Find("GameManager").GetComponent<MoneyScript>().UpdateMoney(distance);
                        GameObject.Find("GameManager").GetComponent<CityManagement>().TryToAddCity(startPos, endPos);
                        GetComponent<Resource>().ConnectTwoCities(startPos, endPos);
                    }
                }
            }
            else if(canDestroy)
            {
                Debug.Log("Distrus");
                Destroy(this.gameObject);
            }
        }
    }

    //functie pt a vedea daca exista sau nu un drum care conecteaza deja cele doua orase
    bool SeeIfCanBuildRoad()
    {
        List<RoadManager> roads = GameObject.Find("GameManager").GetComponent<SpawnRoadManager>().roads;
        foreach(var road in roads)
        {
            if((road.pair[0] == pair[0] && road.pair[1] == pair[1]) || (road.pair[1] == pair[0] && road.pair[0] == pair[1])) return false;
        }
        return true;
    }
}
