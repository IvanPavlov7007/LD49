using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteCameraPositioning : MonoBehaviour
{
    static new Transform camera = null;
    [SerializeField]
    float scaleFactor,maxDist, offset;
    Vector3 normalScale;
    // If no rotates X and Y
    [SerializeField]
    private bool isRotateOnlyY;
    // If no sprite look at camera
    [SerializeField]
    private bool isLookAtPlayer;

    private GameObject player;
    public GameObject Player 
    { 
        get 
        { 
            return player; 
        } 
    }
    private float distanceToTarget;
    public float DistanceToTarget
    {
        get
        {
            return distanceToTarget;
        }
    }


    private void Awake()
    {
        normalScale = transform.localScale;
    }

    void Start()
    {
        if (camera == null)
            camera = Camera.main.transform;
        player = PlayerController.Instance.gameObject;
    }

    void Update()
    {
        GameObject targetObject = camera.gameObject;
        if (isLookAtPlayer)
        {
            targetObject = player;
        }

        distanceToTarget = Vector3.Distance(transform.position, targetObject.transform.position);

        Vector3 targetPostition = targetObject.transform.position;

        if (isRotateOnlyY)
        {
            targetPostition = new Vector3(targetObject.transform.position.x,
                                          this.transform.position.y,
                                          targetObject.transform.position.z);
        }

        //transform.LookAt(targetPostition);

        // Version with x constrain
        transform.localScale = CommonTools.xPlaneVector(normalScale * Mathf.Clamp01(Mathf.Min(maxDist,(maxDist + offset - distanceToTarget)) / maxDist), normalScale.x);

        // Version without x constrain
        //transform.localScale = normalScale * Mathf.Clamp01(Mathf.Min(maxDist, (maxDist + offset - distanceToTarget)) / maxDist); // Version without x constrain
    }
}
