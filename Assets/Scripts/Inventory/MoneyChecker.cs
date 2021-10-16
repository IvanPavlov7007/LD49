using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MoneyChecker : MonoBehaviour
{
    [SerializeField]
    float minCashScore;
    [SerializeField]
    UnityEvent action;

    Inventory inv;

    private void Start()
    {
        inv = GameManager.instance.inventory;
    }


    bool played = false;
    void Update()
    {
        if(inv.money >= minCashScore && !played)
        {
            action.Invoke();
            played = true;
        }
    }
}
