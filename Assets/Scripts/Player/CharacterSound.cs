using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSound : MonoBehaviour
{
    Rigidbody rb;
    AudioSource audioSource;

    [SerializeField]
    AudioClip clip;

    bool playing = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (rb.velocity.magnitude > 0.5f)
        {
            if (!playing)
            {
                playing = true;
                audioSource.Play();
            }
        }
        else
        {
            playing = false;
            audioSource.Stop();
        }
    }

    //TODO: instead of simply audioSource.Stop()
    void FadeOut()
    {

    }
}
