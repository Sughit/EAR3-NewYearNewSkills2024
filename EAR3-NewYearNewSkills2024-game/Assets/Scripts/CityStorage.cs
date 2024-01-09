using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    [HideInInspector]
    public bool canAddWood;
    [HideInInspector]
    public bool canAddOil;
    [HideInInspector]
    public bool canAddRock;
    [HideInInspector]
    public bool canAddSand;

    public float timeToAddWood=2f;
    public float timeToAddOil=2f;
    public float timeToAddRock=2f;
    public float timeToAddSand=2f;

    public Transform iconsParent;
    public GameObject resourceIcon;
    public Sprite[] sprites;

    public void AddResource(string resource)
    {
        if(!resourcesList.Contains(resource)) resourcesList.Add(resource);
    }

    void Start()
    {
        SetResources();
    }

    public void SetResources()
    {
        foreach(Collider2D other in Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y), resourceRange, resourcesMask))
        {
            AddResource(other.gameObject.tag);
            switch(other.gameObject.tag)
            {
                case "Wood":
                canAddWood=true;
                GameObject resource = Instantiate(resourceIcon, iconsParent);
                resource.GetComponentInChildren<Image>().sprite = sprites[0];
                break;

                case "Oil":
                canAddOil=true;
                resource = Instantiate(resourceIcon, iconsParent);
                resource.GetComponentInChildren<Image>().sprite = sprites[1];
                break;

                case "Rock":
                canAddRock=true;
                resource = Instantiate(resourceIcon, iconsParent);
                resource.GetComponentInChildren<Image>().sprite = sprites[2];
                break;

                case "Sand":
                canAddSand=true;
                resource = Instantiate(resourceIcon, iconsParent);
                resource.GetComponentInChildren<Image>().sprite = sprites[3];
                break;

                default:
                Debug.Log("Resource not found");
                break;
            }
        }
    }

    void Update()
    {
        if(resourcesList.Count > 0) 
        {
            if(canAddResources)
            {
                if(canAddWood)
                {
                    AddWoodToCity();
                    canAddWood=false;
                    Invoke("ResetTimerWood", timeToAddWood);
                }
                if(canAddOil)
                {
                    AddOilToCity();
                    canAddOil=false;
                    Invoke("ResetTimerOil", timeToAddOil);
                }
                if(canAddRock)
                {
                    AddRockToCity();
                    canAddRock=false;
                    Invoke("ResetTimerRock", timeToAddRock);
                }
                if(canAddSand)
                {
                    AddSandToCity();
                    canAddSand=false;
                    Invoke("ResetTimerSand", timeToAddSand);
                }
            }
        }
    }

    //functii de adaugat resurse
    void AddWoodToCity()
    {
        wood++;
    }
    void AddOilToCity()
    {
        oil++;
    }
    void AddRockToCity()
    {
        rock++;
    }
    void AddSandToCity()
    {
        sand++;
    }

    //functii de resetat timpul
    void ResetTimerWood()
    {
        canAddWood=true;
    }
    void ResetTimerOil()
    {
        canAddOil=true;
    }
    void ResetTimerRock()
    {
        canAddRock=true;
    }
    void ResetTimerSand()
    {
        canAddSand=true;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.gameObject.transform.position, resourceRange);
    }

    //void AddResourcesToCity()
    // {
    //     foreach(var resource in resourcesList)
    //     {
    //         switch(resource)
    //         {
    //             case "Wood":
    //             wood++;
    //             break;
    //             case "Oil":
    //             oil++;
    //             break;
    //             case "Rock":
    //             rock++;
    //             break;
    //             case "Sand":
    //             sand++;
    //             break;
    //             default:
    //             Debug.Log("This city doesn't have that resource or that resource doesn't exist");
    //             break;
    //         }
    //     }
    // }
}
