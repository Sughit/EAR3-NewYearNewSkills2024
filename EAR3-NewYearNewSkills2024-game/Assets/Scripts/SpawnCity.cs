using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnCity : MonoBehaviour
{
    public float range = 2;
    public GameObject city;
    public string cityName;

    void Awake()
    {
        city.GetComponent<visualScriptCIty>().cityName.text = cityName;  
        float random = Random.Range(-range, range);
        if(random==0) random+=0.01f;
        GameObject cityGO = Instantiate(city, new Vector3(this.transform.position.x + random,this.transform.position.y + random, 0), Quaternion.identity, this.gameObject.transform);
        GameObject.Find("GameManager").GetComponent<Country>().cities.Add(cityGO.GetComponent<CityStorage>());
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(this.gameObject.transform.position, range);
    }
}
