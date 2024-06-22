using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager instance;

    private void Awake()
    {
        instance = this;
    }

    public int currentMoney;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddMoney(int amount)
    {
        currentMoney += amount;
        UIController.instance.UpdateMoneyLabel();
    }

    public bool SpendMoney(int amountToSpend)
    {
        bool canSpend = false;
        if(currentMoney >= amountToSpend)
        {
            canSpend = true;
            currentMoney -= amountToSpend;
        }

        UIController.instance.UpdateMoneyLabel();

        return canSpend;


    }
}
