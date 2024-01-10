using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCity : MonoBehaviour
{
    public float range = 2;
    public GameObject city;

    void Awake()
    {
        Instantiate(city, new Vector3(Random.Range(-range, range), Random.Range(-range, range), 0), Quaternion.identity, this.gameObject.transform);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(this.gameObject.transform.position, range);
    }
}
