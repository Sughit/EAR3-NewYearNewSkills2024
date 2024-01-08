using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    LineRenderer lineRend;
    public Vector3 startPos;
    public Vector3 endPos;

    public bool finishRoad;
    public bool isNew=true;

    void Start()
    {
        lineRend = GetComponent<LineRenderer>();
        lineRend.positionCount = 2;
    }

    void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            if(finishRoad)
            {
                lineRend.SetPosition(0, startPos);
                lineRend.SetPosition(1, endPos);
                isNew=false;
            }
            else if(!finishRoad)
            {
                Debug.Log("distrus");
                Destroy(this.gameObject);
            }
        }
    }
}
