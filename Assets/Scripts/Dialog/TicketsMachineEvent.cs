using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicketsMachineEvent : InteractionEvent
{
    [SerializeField]
    Dialog coin, noCoin;
    DialogPoint dp;

    protected override void Start()
    {
        base.Start();
        dp = GetComponent<DialogPoint>();
    }

    override protected void Update()
    {
        if (Vector3.Distance(player.position, transform.position) < dist && !played)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if(GameManager.instance.inventory.coin)
                {
                    dp.StartDialog(coin);
                }
                else
                {
                    dp.StartDialog(noCoin);
                }
                played = true;
            }
        }
    }

    public void Reset()
    {
        played = false;
        noCoin.Reset();
    }
}
