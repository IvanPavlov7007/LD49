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

    // In range 0,1 (0 - ok, 1 - game over)
    [SerializeField]
    [Range(0f, 1f)]
    private float madnessFactor = 0f;
    public float MadnessFactor
    {
        get
        {
            return madnessFactor;
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

    public void boostSpeed(float multiplier)
    {
        speed *= multiplier;
        runningSpeed *= multiplier;
    }

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        Start();
        rb.isKinematic = false;
    }

    private void OnDisable()
    {
        Start();
        rb.isKinematic = true;
    }

    void Update()
    {
        // Get Input
        velocity = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")) * (Input.GetKey(KeyCode.LeftShift) ? runningSpeed : speed);
    }

    private void FixedUpdate()
    {
        rb.velocity = CommonTools.yPlaneVector(velocity, rb.velocity.y);
    }
}
