using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            if(finishRoad && startPos != endPos && startPos != Vector3.zero && endPos != Vector3.zero)
            {
                if(SceneManager.GetActiveScene().name != "Main Menu")
                {
                    lineRend.SetPosition(0, new Vector3(startPos.x, startPos.y, -0.1f));
                    lineRend.SetPosition(1, new Vector3(endPos.x, endPos.y, -0.1f));
                }
                else
                {
                    lineRend.SetPosition(0, new Vector3(startPos.x, startPos.y, 89.9f));
                    lineRend.SetPosition(1, new Vector3(endPos.x, endPos.y, 89.9f));
                }
                isNew=false;
                finishRoad=false;
                canDestroy=false;
                float distance = Vector3.Distance(startPos, endPos);
                if(SceneManager.GetActiveScene().name != "Main Menu")
                {
                    if(GameObject.Find("GameManager").GetComponent<MoneyScript>().CalculateRoadCost(distance) > MoneyScript.money) 
                    {
                        Debug.Log("Too expensive to build");
                        Destroy(this.gameObject);
                    }
                }
                
                
                    pair.Add(startPos);
                    pair.Add(endPos);
                    if(!SeeIfCanBuildRoad()) Destroy(this.gameObject);
                    else if(SceneManager.GetActiveScene().name != "Main Menu")
                    {
                        Debug.Log("Nu suntem in meniu");
                        GameObject.FindWithTag("GameManager").GetComponent<SpawnRoadManager>().roads.Add(this);
                        GameObject.FindWithTag("GameManager").GetComponent<MoneyScript>().UpdateMoney(distance);
                        GameObject.FindWithTag("GameManager").GetComponent<CityManagement>().TryToAddCity(startPos, endPos);
                        GetComponent<Resource>().ConnectTwoCities(startPos, endPos);
                        GameObject.FindWithTag("GameManager").GetComponent<Country>().numRoad++;
                    }
                    else if(SceneManager.GetActiveScene().name == "Main Menu")
                    {
                        Debug.Log("Suntem in meniu");
                        GameObject.FindWithTag("GameManager").GetComponent<SpawnRoadManager>().roads.Add(this);
                        GameObject.FindWithTag("GameManager").GetComponent<CityManagement>().TryToAddCity(startPos, endPos);
                        GetComponent<Resource>().ConnectTwoCities(startPos, endPos);
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
        List<RoadManager> roads = GameObject.FindWithTag("GameManager").GetComponent<SpawnRoadManager>().roads;
        foreach(var road in roads)
        {
            if((road.pair[0] == pair[0] && road.pair[1] == pair[1]) || (road.pair[1] == pair[0] && road.pair[0] == pair[1])) return false;
        }
        return true;
    }
}
