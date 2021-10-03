using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitEvent : MonoBehaviour, SequenceEvent
{
    void Start()
    {
        Started = true;
    }

    [SerializeField] float duration;

    float elapsedTime = 0f;
    public event System.Action finished;

    public bool Started { get; private set; }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (duration >= elapsedTime)
        {
            if (finished != null)
                finished();
            Destroy(this);
        }
    }
}
