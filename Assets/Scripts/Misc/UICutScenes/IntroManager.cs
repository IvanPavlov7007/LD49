using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Events;

public class IntroManager : MonoBehaviour
{
    [SerializeField]
    PlayableDirector pressE_Intro;

    [SerializeField]
    UnityEvent onStartBlackScreen, onEndBlackScreen;

    bool played = false;

    private void Start()
    {
        onStartBlackScreen.Invoke();
    }

    void Update()
    {
        if(!played && Input.GetKeyDown(KeyCode.E))
        {
            pressE_Intro.enabled = false;
            played = true;
            onEndBlackScreen.Invoke();
        }
    }
}
