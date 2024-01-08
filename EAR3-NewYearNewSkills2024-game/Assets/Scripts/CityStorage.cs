using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityStorage : MonoBehaviour
{
    public List<string> resourcesList = new List<string>();
    public int wood;
    public int oil;
    public int rock;
    public int sand;

    public void AddResource(string resource)
    {
        if(!resourcesList.Contains(resource)) resourcesList.Add(resource);
    }

    void Update()
    {
        Invoke("AddResourcesToCity", 1f);
    }

    void AddResourcesToCity()
    {
        foreach(var resource in resourcesList)
        {
            switch(resource)
            {
                case "wood":
                wood++;
                break;
                case "oil":
                oil++;
                break;
                case "rock":
                rock++;
                break;
                case "sand":
                sand++;
                break;
                default:
                Debug.Log("This city doesn't have that resource or that resource doesn't exist");
                break;
            }
        }
    }
}
