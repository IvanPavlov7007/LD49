using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public Inventory inventory;

    public GameObject pauseMenu;

    public bool GameStopped { get; private set; }

    public void ContinueGame()
    {
        GameStopped = false;
        PlayerController.Instance.enabled = true;
        //Time.timeScale = 1f;
    }

    public void StopGame()
    {
        GameStopped = true;
        //Time.timeScale = 0f;
        PlayerController.Instance.enabled = false;
    }

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    private void Update()
    {
        //if ((Input.GetKeyDown(KeyCode.Escape) || pauseMenu.activeSelf) && !GameStopped)
        //{
        //    pauseMenu.SetActive(true);
        //    gameObject.SetActive(false);
        //}
    }

}
