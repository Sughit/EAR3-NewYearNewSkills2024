using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseCityCanvas : MonoBehaviour
{
    public static bool open;
    void Update()
    {
        if(!CloseCityCanvas.open)
        {
            this.gameObject.SetActive(false);
        }
    }
}
