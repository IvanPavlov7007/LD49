using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableMovement : MonoBehaviour
{
    PlayerController controller;
    

    private void OnEnable()
    {
        PlayerController.Instance.enabled = false;
    }

    private void OnDisable()
    {
        PlayerController.Instance.enabled = true;
    }
}
