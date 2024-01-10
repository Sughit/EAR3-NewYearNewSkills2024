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
        Instantiate(city, new Vector3(this.transform.position.x + Random.Range(-range, range),this.transform.position.y + Random.Range(-range, range), 0), Quaternion.identity, this.gameObject.transform);
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(this.gameObject.transform.position, range);
    }
}
