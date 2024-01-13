using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadBluePrint : MonoBehaviour
{
    void Update()
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        GetComponent<LineRenderer>().SetPosition(1, new Vector3(worldPosition.x, worldPosition.y, 0));
        if(Input.GetMouseButtonUp(0)) Destroy(this.gameObject);
    }
}
