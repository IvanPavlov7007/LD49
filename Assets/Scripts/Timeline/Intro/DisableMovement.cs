using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableMovement : MonoBehaviour
{
    PlayerController controller;
    Rigidbody rb;



    private void OnEnable()
    {
        controller = PlayerController.Instance;
        controller.enabled = false;
        rb = controller.GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    private void OnDisable()
    {
        controller.enabled = true;
        rb.isKinematic = false;
    }
}
