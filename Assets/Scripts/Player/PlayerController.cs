using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed, runningSpeed;

    // Singletone pattern
    private static PlayerController instance;
    public static PlayerController Instance { get { return instance; } }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    void Update()
    {
        // Get Input
        Vector3 vel = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")) * (Input.GetKey(KeyCode.LeftShift) ? runningSpeed : speed);
        transform.Translate(vel * Time.deltaTime);
    }
}
