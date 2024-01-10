using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectCountry : MonoBehaviour
{
    public string countryName;
    public Text nameText;

    void Awake()
    {
        nameText.text = countryName;
    }

    public void ChooseCountry()
    {
        SceneManager.LoadScene(countryName);
    }
}
