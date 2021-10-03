using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "collection", menuName = "ScriptableObjects/SpawnSpriteVariantCollection", order = 1)]
public class SpriteVariantCollection : ScriptableObject
{

    public Sprite[] sprites;
    
    public Sprite getRandomSprite()
    {
        return sprites[Random.Range(0, sprites.Length - 1)];
    }
}
