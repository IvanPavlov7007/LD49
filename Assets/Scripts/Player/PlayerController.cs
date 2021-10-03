using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed, runningSpeed;

    [SerializeField]
    private SpriteRenderer spriteRenderer;
    public SpriteRenderer SpriteRenderer
    {
        get
        {
            return spriteRenderer;
        }
    }

    // Singletone pattern
    private static PlayerController instance;
    public static PlayerController Instance { get { return instance; } }
    private Vector3 velocity;
    Rigidbody rb;

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

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Get Input
        velocity = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")) * (Input.GetKey(KeyCode.LeftShift) ? runningSpeed : speed);
    }

    private void FixedUpdate()
    {
        rb.velocity = velocity;
    }
}
