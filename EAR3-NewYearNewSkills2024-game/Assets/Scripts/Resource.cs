using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resource : MonoBehaviour
{
    GameObject cityAGO, cityBGO;
    public GameObject resourceIcon;

    public void ConnectTwoCities(Vector3 cityA, Vector3 cityB)
    {
        foreach(var city in GameObject.FindGameObjectsWithTag("City"))
        {
            if(city.transform.position == cityA) 
            {
                cityAGO = city;
                GameObject.FindWithTag("GameManager").GetComponent<CityManagement>().TryToAddCityGO(cityAGO);
                if(cityBGO != null) break;
            }
            if(city.transform.position == cityB)
            {
                cityBGO = city;
                GameObject.FindWithTag("GameManager").GetComponent<CityManagement>().TryToAddCityGO(cityBGO);
                if(cityAGO != null) break;
            }
        }

        ShareResources(cityAGO, cityBGO);
    }

    void ShareResources(GameObject cityA, GameObject cityB)
    {
        //daca cityA are lemn si cityB nu
        if(cityA.GetComponent<CityStorage>().resourcesList.Contains("Wood") && !cityB.GetComponent<CityStorage>().resourcesList.Contains("Wood"))
        {
            cityB.GetComponent<CityStorage>().resourcesList.Add("Wood");
            // cityB.GetComponent<CityStorage>().timeToAddWood += 1;
            // cityB.GetComponent<CityStorage>().canAddWood=true;
            GameObject resource = Instantiate(resourceIcon, cityB.GetComponent<CityStorage>().iconsParent);
            resource.GetComponentInChildren<Image>().sprite = cityB.GetComponent<CityStorage>().sprites[0];

            // cityA.GetComponent<CityStorage>().timeToAddWood += 1;
        }
        //daca cityB are lemn si cityA nu
        else if(!cityA.GetComponent<CityStorage>().resourcesList.Contains("Wood") && cityB.GetComponent<CityStorage>().resourcesList.Contains("Wood"))
        {
            cityA.GetComponent<CityStorage>().resourcesList.Add("Wood");
            // cityA.GetComponent<CityStorage>().timeToAddWood += 1;
            // cityA.GetComponent<CityStorage>().canAddWood=true;
            GameObject resource = Instantiate(resourceIcon, cityA.GetComponent<CityStorage>().iconsParent);
            resource.GetComponentInChildren<Image>().sprite = cityA.GetComponent<CityStorage>().sprites[0];

            // cityB.GetComponent<CityStorage>().timeToAddWood += 1;
        }

        //daca cityA are ulei si cityB nu
        if(cityA.GetComponent<CityStorage>().resourcesList.Contains("Oil") && !cityB.GetComponent<CityStorage>().resourcesList.Contains("Oil"))
        {
            cityB.GetComponent<CityStorage>().resourcesList.Add("Oil");
            // cityB.GetComponent<CityStorage>().timeToAddOil += 1;
            // cityB.GetComponent<CityStorage>().canAddOil=true;
            GameObject resource = Instantiate(resourceIcon, cityB.GetComponent<CityStorage>().iconsParent);
            resource.GetComponentInChildren<Image>().sprite = cityB.GetComponent<CityStorage>().sprites[1];

            // cityA.GetComponent<CityStorage>().timeToAddOil += 1;
        }
        //daca cityB are ulei si cityA nu
        else if(!cityA.GetComponent<CityStorage>().resourcesList.Contains("Oil") && cityB.GetComponent<CityStorage>().resourcesList.Contains("Oil"))
        {
            cityA.GetComponent<CityStorage>().resourcesList.Add("Oil");
            // cityA.GetComponent<CityStorage>().timeToAddOil += 1;
            // cityA.GetComponent<CityStorage>().canAddOil=true;
            GameObject resource = Instantiate(resourceIcon, cityA.GetComponent<CityStorage>().iconsParent);
            resource.GetComponentInChildren<Image>().sprite = cityA.GetComponent<CityStorage>().sprites[1];

            // cityB.GetComponent<CityStorage>().timeToAddOil += 1;
        }

        //daca cityA are piatra si cityB nu
        if(cityA.GetComponent<CityStorage>().resourcesList.Contains("Rock") && !cityB.GetComponent<CityStorage>().resourcesList.Contains("Rock"))
        {
            cityB.GetComponent<CityStorage>().resourcesList.Add("Rock");
            // cityB.GetComponent<CityStorage>().timeToAddRock += 1;
            // cityB.GetComponent<CityStorage>().canAddRock=true;
            GameObject resource = Instantiate(resourceIcon, cityB.GetComponent<CityStorage>().iconsParent);
            resource.GetComponentInChildren<Image>().sprite = cityB.GetComponent<CityStorage>().sprites[2];

            // cityA.GetComponent<CityStorage>().timeToAddRock += 1;
        }
        //daca cityB are piatra si cityA nu
        else if(!cityA.GetComponent<CityStorage>().resourcesList.Contains("Rock") && cityB.GetComponent<CityStorage>().resourcesList.Contains("Rock"))
        {
            cityA.GetComponent<CityStorage>().resourcesList.Add("Rock");
            // cityA.GetComponent<CityStorage>().timeToAddRock += 1;
            // cityA.GetComponent<CityStorage>().canAddRock=true;
            GameObject resource = Instantiate(resourceIcon, cityA.GetComponent<CityStorage>().iconsParent);
            resource.GetComponentInChildren<Image>().sprite = cityA.GetComponent<CityStorage>().sprites[2];
            
            // cityB.GetComponent<CityStorage>().timeToAddRock += 1;
        }

        //daca cityA are nisip si cityB nu
        if(cityA.GetComponent<CityStorage>().resourcesList.Contains("Sand") && !cityB.GetComponent<CityStorage>().resourcesList.Contains("Sand"))
        {
            cityB.GetComponent<CityStorage>().resourcesList.Add("Sand");
            // cityB.GetComponent<CityStorage>().timeToAddSand += 1;
            // cityB.GetComponent<CityStorage>().canAddSand=true;
            GameObject resource = Instantiate(resourceIcon, cityB.GetComponent<CityStorage>().iconsParent);
            resource.GetComponentInChildren<Image>().sprite = cityB.GetComponent<CityStorage>().sprites[3];

            // cityA.GetComponent<CityStorage>().timeToAddSand += 1;
        }
        //daca cityB are nisip si cityA nu
        else if(!cityA.GetComponent<CityStorage>().resourcesList.Contains("Sand") && cityB.GetComponent<CityStorage>().resourcesList.Contains("Sand"))
        {
            cityA.GetComponent<CityStorage>().resourcesList.Add("Sand");
            // cityA.GetComponent<CityStorage>().timeToAddSand += 1;
            // cityA.GetComponent<CityStorage>().canAddSand=true;
            GameObject resource = Instantiate(resourceIcon, cityA.GetComponent<CityStorage>().iconsParent);
            resource.GetComponentInChildren<Image>().sprite = cityA.GetComponent<CityStorage>().sprites[3];

            // cityB.GetComponent<CityStorage>().timeToAddSand += 1;
        }
    }
}
