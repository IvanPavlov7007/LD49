using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class RavenFly : MonoBehaviour
{
    PlayableDirector dir;
    public float dist;
    Transform player;

    protected void Start()
    {
        dir = GetComponentInChildren<PlayableDirector>();
        player = PlayerController.Instance.transform;
    }
    bool played = false;
    protected void Update()
    {
        if (Vector3.Distance(player.position,transform.position) < dist && ! played)
        {
            played = true;
            dir.Play();
        }
    }
}
