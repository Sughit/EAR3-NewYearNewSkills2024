using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    GameObject cityAGO, cityBGO;

    public void ConnectTwoCities(Vector3 cityA, Vector3 cityB)
    {
        foreach(var city in GameObject.FindGameObjectsWithTag("City"))
        {
            if(city.transform.position == cityA) 
            {
                cityAGO = city;
                GameObject.Find("GameManager").GetComponent<CityManagement>().TryToAddCityGO(cityAGO);
                if(cityBGO != null) break;
            }
            if(city.transform.position == cityB)
            {
                cityBGO = city;
                GameObject.Find("GameManager").GetComponent<CityManagement>().TryToAddCityGO(cityBGO);
                if(cityAGO != null) break;
            }
        }

        ShareResources(cityAGO, cityBGO);
    }

    void ShareResources(GameObject cityA, GameObject cityB)
    {
        //daca cityA are lemn si cityB nu
        if(cityA.GetComponent<CityStorage>().resourcesList.Contains("Wood") && !cityB.GetComponent<CityStorage>().resourcesList.Contains("Wood"))
            cityB.GetComponent<CityStorage>().resourcesList.Add("Wood");
        //daca cityB are lemn si cityA nu
        else if(!cityA.GetComponent<CityStorage>().resourcesList.Contains("Wood") && cityB.GetComponent<CityStorage>().resourcesList.Contains("Wood"))
            cityA.GetComponent<CityStorage>().resourcesList.Add("Wood");

        //daca cityA are ulei si cityB nu
        if(cityA.GetComponent<CityStorage>().resourcesList.Contains("Oil") && !cityB.GetComponent<CityStorage>().resourcesList.Contains("Oil"))
            cityB.GetComponent<CityStorage>().resourcesList.Add("Oil");
        //daca cityB are ulei si cityA nu
        else if(!cityA.GetComponent<CityStorage>().resourcesList.Contains("Oil") && cityB.GetComponent<CityStorage>().resourcesList.Contains("Oil"))
            cityA.GetComponent<CityStorage>().resourcesList.Add("Oil");

        //daca cityA are piatra si cityB nu
        if(cityA.GetComponent<CityStorage>().resourcesList.Contains("Rock") && !cityB.GetComponent<CityStorage>().resourcesList.Contains("Rock"))
            cityB.GetComponent<CityStorage>().resourcesList.Add("Rock");
        //daca cityB are piatra si cityA nu
        else if(!cityA.GetComponent<CityStorage>().resourcesList.Contains("Rock") && cityB.GetComponent<CityStorage>().resourcesList.Contains("Rock"))
            cityA.GetComponent<CityStorage>().resourcesList.Add("Rock");

        //daca cityA are nisip si cityB nu
        if(cityA.GetComponent<CityStorage>().resourcesList.Contains("Sand") && !cityB.GetComponent<CityStorage>().resourcesList.Contains("Sand"))
            cityB.GetComponent<CityStorage>().resourcesList.Add("Sand");
        //daca cityB are nisip si cityA nu
        else if(!cityA.GetComponent<CityStorage>().resourcesList.Contains("Sand") && cityB.GetComponent<CityStorage>().resourcesList.Contains("Sand"))
            cityA.GetComponent<CityStorage>().resourcesList.Add("Sand");
    }
}
