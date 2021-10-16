using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableMovement : MonoBehaviour
{
    PlayerController controller;
    

    private void OnEnable()
    {
        PlayerController.Instance.enabled = false;
        PlayerController.Instance.GetComponent<CharacterSound>().enabled = false;
    }

    private void OnDisable()
    {
        PlayerController.Instance.enabled = true;
        PlayerController.Instance.GetComponent<CharacterSound>().enabled = true;
    }
}
