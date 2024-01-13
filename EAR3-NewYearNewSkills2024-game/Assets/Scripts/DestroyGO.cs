using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGO : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(this);
        Destroy(gameObject, 2);
    }
}
