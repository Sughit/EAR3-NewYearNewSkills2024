using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Country : MonoBehaviour
{
    public Text nameText;
    public List<CityStorage> cities = new List<CityStorage>();
    public Text numRoadText;
    public int numRoad;

    public GameObject selectCountry;
    public GameObject results;
    public Text finalRoadText;
    public Text finalMoneyText;
    public Text finalCountryText;

    void Awake()
    {
        nameText.text = SceneManager.GetActiveScene().name;
    }

    void Update()
    {
        if(!results.activeSelf) CheckCities();
        numRoadText.text = $": {numRoad}";
    }

    public void NextCountry()
    {
        results.SetActive(false);
        selectCountry.SetActive(true);
    }

    void CheckCities()
    {
        int num=0;
        foreach(var city in cities)
        {
            if(city.resourcesList.Count == 4) 
            {
                num++;
            }
            else
            {
                break;
            }
        }
        if(num == cities.Count)
        {
            finalCountryText.text = $"You ruled {SceneManager.GetActiveScene().name}";
            finalMoneyText.text = $"Money used: {250 - MoneyScript.money}";
            finalRoadText.text = $"Roads used: {numRoad}";
            MoneyScript.money=250;
            results.SetActive(true);
            
        }
           
    }
}
