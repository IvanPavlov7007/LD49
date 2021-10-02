using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteCameraPositioning : MonoBehaviour
{
    static new Transform camera = null;
    [SerializeField]
    float scaleFactor,maxDist, optimalDist;
    Vector3 normalScale;

    private void Awake()
    {
        normalScale = transform.localScale;
    }

    void Start()
    {
        if (camera == null)
            camera = Camera.main.transform;

    }

    void Update()
    {
        float dist = Vector3.Distance(transform.position, camera.position);

        transform.LookAt(camera);
        transform.localScale = normalScale * Mathf.Clamp01((maxDist - dist) / maxDist);
    }
}
