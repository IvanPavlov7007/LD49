using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    [SerializeField] float speed, runningSpeed;

    void Update()
    {
        Vector3 vel = new Vector3(Input.GetAxis("Horizontal"),0f, Input.GetAxis("Vertical")) * (Input.GetKey(KeyCode.LeftShift) ? runningSpeed : speed);
        transform.Translate(vel * Time.deltaTime);
    }
}
