using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Pixelplacement;

public class PlayEvent : MonoBehaviour
{
    [SerializeField]
    UnityEvent action;
    [SerializeField]
    float delay = 0f;

    public void Play()
    {
        StartCoroutine(play());
    }

    IEnumerator play()
    {
        yield return new WaitForSeconds(delay);
        action.Invoke();
    }
}
