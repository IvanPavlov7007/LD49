using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowGenerator : MonoBehaviour
{
    GameObject sprite;
    public Vector3 rotation;
    [SerializeField]
    Material shadowMaterial;
    void Start()
    {
        sprite = GetComponentInChildren<SpriteRenderer>().gameObject;
        var shadow = Instantiate(sprite, transform.position, Quaternion.Euler(rotation), transform);
        shadow.GetComponent<SpriteRenderer>().material = shadowMaterial;
    }

    void Update()
    {
        
    }
}
