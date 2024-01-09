using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityStorage : MonoBehaviour
{
    public List<string> resourcesList = new List<string>();
    public float resourceRange = 2;
    public LayerMask resourcesMask;
    public int wood;
    public int oil;
    public int rock;
    public int sand;

    bool canAddResources=true;
    public float timeToAddResource=2f;

    public void AddResource(string resource)
    {
        if(!resourcesList.Contains(resource)) resourcesList.Add(resource);
    }

    void Start()
    {
        foreach(Collider2D other in Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y), resourceRange, resourcesMask))
        {
            AddResource(other.gameObject.tag);
        }
    }

    void Update()
    {
        if(resourcesList.Count > 0) 
        {
            if(canAddResources)
            {
                AddResourcesToCity();
                canAddResources=false;
                Invoke("ResetTimer", timeToAddResource);
            }
        }
    }

    void AddResourcesToCity()
    {
        foreach(var resource in resourcesList)
        {
            switch(resource)
            {
                case "Wood":
                wood++;
                break;
                case "Oil":
                oil++;
                break;
                case "Rock":
                rock++;
                break;
                case "Sand":
                sand++;
                break;
                default:
                Debug.Log("This city doesn't have that resource or that resource doesn't exist");
                break;
            }
        }
    }

    void ResetTimer()
    {
        canAddResources=true;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.gameObject.transform.position, resourceRange);
    }
}
