using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyScript : MonoBehaviour
{
    public static int money = 250;
    public Text moneyText;
    public int costPerKm;
    int currentRoads;

    public int CalculateRoadCost(float distance)
    {
        int cost = (int)distance * costPerKm;
        return cost;
    }

    public void UpdateMoney(float distance)
    {
        money -= (int)distance * costPerKm;
        moneyText.text = $"Money: {money}";
    }

    void Start()
    {
        moneyText.text = $"Money: {money}";
    }
}
