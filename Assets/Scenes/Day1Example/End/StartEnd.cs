using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class StartEnd : MonoBehaviour
{
    PlayableDirector director;

    [SerializeField]
    PlayableDirector intro;

    private void Start()
    {
        director = GetComponent<PlayableDirector>();
    }

    private void OnTriggerEnter(Collider other)
    {
        intro.Stop();
        PlayerController.Instance.GetComponent<AudioSource>().volume = 0f;
        Camera.main.GetComponent<AudioSource>().Stop();
        director.Play();
    }
}
