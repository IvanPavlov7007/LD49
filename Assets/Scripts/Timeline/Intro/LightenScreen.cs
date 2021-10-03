using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightenScreen : MonoBehaviour, SequenceEvent
{
    TransparencyChangingComponent dim;
    void Start()
    {
        dim = Camera.main.GetComponent<DimManager>();
        Started = false;
    }

    [SerializeField] float duration;

    float elapsedTime = 0f;

    public event Action finished;

    public bool Started { get; private set; }

    void Update()
    {
        if (Started)
        {
            elapsedTime += Time.deltaTime;
            dim.Visibility = elapsedTime / duration;
            if (dim.Visibility >= 1f)
            {
                if (finished != null)
                    finished();
                Destroy(this);
            }
        }
    }

    public void StartLighten()
    {
        Started = true;
    }

    public void SetFullDimmed()
    {
        dim.Visibility = 0f;
    }


}
