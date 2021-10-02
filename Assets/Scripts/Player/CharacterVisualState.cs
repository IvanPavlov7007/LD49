using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterVisualState : MonoBehaviour
{
    public Sprite[] states;
    private bool initalState, flipped;
    private const float fortyDegSin = 0.78539f;
    private SpriteRenderer spriteRenderer;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        initalState = true;
        flipped = true;
    }

    void Update()
    {
        float curAngleRadians = getCurrentAngleRadians(rb.velocity);
        if (Mathf.Abs(Mathf.Sin(curAngleRadians)) > fortyDegSin)
        {
            if (initalState)
            {
                initalState = false;
                spriteRenderer.sprite = states[0];
            }
        }
        else if (!initalState)
        {
            initalState = true;
            spriteRenderer.sprite = states[1];
        }

        if (initalState && Mathf.Abs(curAngleRadians) > 1.58f)
        {
            if (!flipped)
            {
                flipped = true;
                spriteRenderer.flipX = true;
            }
        }
        else if (flipped)
        {
            flipped = false;
            spriteRenderer.flipX = false;
        }
    }

    private float getCurrentAngleRadians(Vector3 direction)
    {
        return Vector3.SignedAngle(Vector3.right, direction,Vector3.up) * Mathf.PI * 0.00555f;
    }
}
