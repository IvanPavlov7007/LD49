using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeedSpritesVariant : MonoBehaviour
{
    SpriteRenderer sr;
    [SerializeField]
    SpriteVariantCollection c;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = c.getRandomSprite();
    }
}
