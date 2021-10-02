using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentObject : MonoBehaviour
{
    public SpriteCameraPositioning SCP;
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private bool isFadeOutWhenClose;
    [SerializeField]
    private Vector2 fadeOutRange; // from 1 to ~0
    [SerializeField] 
    private Vector2 fadeOutDistance;

    protected void Awake()
    {
        
    }

    protected void Update()
    {
        if (isFadeOutWhenClose)
        {
            ChangeAlpha(SCP.DistanceToTarget);
        }
    }

    private void ChangeAlpha(float distance)
    {
        float newAlpha = 1f;

        if (distance > fadeOutDistance.x)
        {
            newAlpha = fadeOutRange.x;
        }
        else if (distance < fadeOutDistance.y)
        {
            newAlpha = fadeOutRange.y;
        }
        else
        {
            Debug.Log(fadeOutDistance.y / distance);
            newAlpha = Mathf.Lerp(fadeOutRange.x, fadeOutRange.y, fadeOutDistance.y / distance);
        }

        spriteRenderer.color = new Color(spriteRenderer.color.r,
                                         spriteRenderer.color.g,
                                         spriteRenderer.color.b,
                                         newAlpha);
    }
}
