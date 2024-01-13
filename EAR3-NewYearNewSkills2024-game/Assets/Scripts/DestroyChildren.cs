using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyChildren : MonoBehaviour
{
    public void DestroyAllChildren()
    {
        for(int i=0; i<this.transform.childCount; i++)
        {
            Destroy(this.transform.GetChild(i).gameObject);
        }
    }

    public void RemoveAllCities()
    {
        this.gameObject.GetComponent<CityManagement>().cityPos.Clear();
        this.gameObject.GetComponent<CityManagement>().cityGO.Clear();
        this.gameObject.GetComponent<SpawnRoadManager>().roads.Clear();
    }
}
