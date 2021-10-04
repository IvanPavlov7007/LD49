using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimScreen : MonoBehaviour
{
    DimManager dim;
    void OnEnable()
    {
        Camera.main.GetComponent<DimManager>().Visibility = 0f;
    }
}
