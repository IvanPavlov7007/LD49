using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroManager : MonoBehaviour
{
    LightenScreen lightenScreen;
    private void Awake()
    {
        lightenScreen = gameObject.AddComponent<LightenScreen>();
    }


    void Start()
    {
        
    }
    void Update()
    {
        
    }
}
