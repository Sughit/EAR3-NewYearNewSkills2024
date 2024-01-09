using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityManagement : MonoBehaviour
{
    public List<Vector3> cityPos = new List<Vector3>();
    public List<GameObject> cityGO = new List<GameObject>();

    public void TryToAddCity(Vector3 cityA, Vector3 cityB)
    {
        if(!cityPos.Contains(cityA)) cityPos.Add(cityA);
        if(!cityPos.Contains(cityB)) cityPos.Add(cityB);
    }

    public void TryToAddCityGO(GameObject city)
    {
        if(!cityGO.Contains(city)) cityGO.Add(city);
    }
}
