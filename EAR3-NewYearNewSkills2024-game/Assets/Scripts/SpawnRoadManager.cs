using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRoadManager : MonoBehaviour
{
    public GameObject roadManager;
    public bool canBuildRoad=true;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(canBuildRoad)
            {
                Instantiate(roadManager, this.gameObject.transform);
                canBuildRoad=false;
            }
        }
    }
}
