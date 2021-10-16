using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;

public class TweenRotate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Tween.LocalRotation(transform, new Vector3(0f, 15f, 0f), 1f, 0f, Tween.EaseInOut, Tween.LoopType.PingPong);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
