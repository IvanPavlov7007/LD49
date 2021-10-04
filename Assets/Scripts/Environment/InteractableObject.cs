using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class InteractableObject : EnvironmentObject
{
    [SerializeField]
    private float interactDistance;
    [SerializeField]
    private KeyCode keyToInteract = KeyCode.E;
    [SerializeField]
    private UnityEvent OnInteractRange;
    [SerializeField]
    private UnityEvent ExitInteractRange;
    [SerializeField]
    private UnityEvent OnInteractEvent;

    private bool isInteracted = false;


    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Update()
    { 
        base.Awake();

        // Check interact, show text
        if (!isInteracted && SCP.DistanceToTarget < interactDistance)
        {
            if(OnInteractRange != null) OnInteractRange.Invoke();

            if (Input.GetKey(keyToInteract) && OnInteractEvent != null)
            {
                isInteracted = true;
                OnInteractEvent.Invoke();
            }
        }
        else
        {
            if (ExitInteractRange != null) ExitInteractRange.Invoke();
        }

    }

    public void PrintInteract()
    {
        Debug.Log("Interacted");
    }
}
