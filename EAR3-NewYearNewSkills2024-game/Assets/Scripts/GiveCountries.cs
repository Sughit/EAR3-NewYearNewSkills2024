using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveCountries : MonoBehaviour
{
    public Transform country1, country2, country3;
    public GameObject[] countries;

    int rand1, rand2, rand3;

    void Awake()
    {
        GiveRandomCountries();
    }

    void GiveRandomCountries()
    {
        rand1 = Random.Range(0, countries.Length);
        Instantiate(countries[rand1], country1);
        do
        {
            rand2 = Random.Range(0, countries.Length);
        }while(rand2 == rand1);
        Instantiate(countries[rand2], country2);
        do
        {
            rand3 = Random.Range(0, countries.Length);
        }while(rand2 == rand3 && rand1 == rand3);
        Instantiate(countries[rand3], country3);
    }
}
