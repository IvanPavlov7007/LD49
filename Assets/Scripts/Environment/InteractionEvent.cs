using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractionEvent : MonoBehaviour
{
    public float dist;
    Transform player;

    [SerializeField]
    private UnityEvent action;

    protected void Start()
    {
        player = PlayerController.Instance.transform;
    }
    bool played = false;
    protected void Update()
    {
        if (Vector3.Distance(player.position, transform.position) < dist && !played)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                action.Invoke();
                played = true;
            }
        }
    }
}
