using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    public string resource;

    void OnColliderStay2D(Collider2D other)
    {
        if(other.tag=="GetResources")
        {
            other.gameObject.transform.parent.GetComponent<CityStorage>().AddResource(resource);
        }
    }
}
