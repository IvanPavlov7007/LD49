using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractionEvent : MonoBehaviour
{
    public float dist;
    protected Transform player;

    [SerializeField]
    protected UnityEvent action;

    protected virtual void Start()
    {
        player = PlayerController.Instance.transform;
    }
    protected bool played = false;
    protected virtual void Update()
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

    public virtual void Reset()
    {
        played = false;
    }
}
