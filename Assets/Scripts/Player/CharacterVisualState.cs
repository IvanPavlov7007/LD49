using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterVisualState : MonoBehaviour
{
    [SerializeField]
    private PlayerController playerController;

    public Sprite[] states;
    private bool initalState, flipped;
    private const float fortyDegSin = 0.78539f;

    private void Start()
    {
        playerController.SpriteRenderer.sprite = states[0];
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            // Back sprite
            playerController.SpriteRenderer.sprite = states[0];
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            // Left sprite
            playerController.SpriteRenderer.sprite = states[1];
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            // Right sprite
            playerController.SpriteRenderer.sprite = states[2];
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            // Front sprite
            playerController.SpriteRenderer.sprite = states[3];
        }
    }

}
