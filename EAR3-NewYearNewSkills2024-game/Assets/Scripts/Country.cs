using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Country : MonoBehaviour
{
    public Text nameText;

    void Awake()
    {
        nameText.text = SceneManager.GetActiveScene().name;
    }
}
