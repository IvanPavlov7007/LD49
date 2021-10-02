using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TransparencyChangingComponent : MonoBehaviour{


    public abstract float Visibility
    {
        get;
        set;
    }

    void setVisibility(float n)
    {
        Visibility = n;
    }

    protected virtual void Awake()
    {
    }

    protected virtual void Start()
    {
        if (!gameObject.activeInHierarchy)
        {
            Visibility = 0f;
        }
    }
}
