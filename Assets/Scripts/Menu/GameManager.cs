using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public GameObject pauseMenu;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || pauseMenu.activeSelf)
        {
            pauseMenu.SetActive(true);
            gameObject.SetActive(false);
            Time.timeScale = 0f;
        }
    }

}
