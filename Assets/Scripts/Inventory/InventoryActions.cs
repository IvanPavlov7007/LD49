using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryActions : MonoBehaviour
{
    Inventory inventory;
    void Start()
    {
        inventory = GameManager.instance.inventory;
        inventory.coin = false;
        inventory.money = 0f;
    }

    public void AddCoin()
    {
        inventory.coin = true;
    }

    public void RemoveCoin()
    {
        inventory.coin = false;
    }

    public void AddMoney(float amount)
    {
        inventory.money += amount;
    }
}
