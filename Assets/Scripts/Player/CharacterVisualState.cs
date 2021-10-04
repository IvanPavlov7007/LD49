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
    GameManager gm;


    private void Start()
    {
        playerController.SpriteRenderer.sprite = states[0];
        gm = GameManager.instance;
    }

    void Update()
    {
        if (!gm.GameStopped)
        {
            if (Input.GetKey(KeyCode.W))
            {
                // Back sprite
                playerController.SpriteRenderer.sprite = states[0];
                if (Input.GetKey(KeyCode.A))
                {
                    // Left sprite
                    playerController.SpriteRenderer.sprite = states[1];
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    // Right sprite
                    playerController.SpriteRenderer.sprite = states[2];
                }
            }
            else if (Input.GetKey(KeyCode.A))
            {
                // Left sprite
                playerController.SpriteRenderer.sprite = states[1];
            }
            else if (Input.GetKey(KeyCode.D))
            {
                // Right sprite
                playerController.SpriteRenderer.sprite = states[2];
            }
            else
            {
                // Front sprite
                playerController.SpriteRenderer.sprite = states[3];
            }
        }
    }

}
