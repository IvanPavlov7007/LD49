using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextController : MonoBehaviour
{
    TextMeshProUGUI tmpro;
    void Start()
    {
        tmpro = GetComponent<TextMeshProUGUI>();
    }
}
