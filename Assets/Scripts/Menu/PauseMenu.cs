using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    bool oneFrameAfterEnableWaited = true;

    private void OnEnable()
    {
        oneFrameAfterEnableWaited = false;
    }

    void Update()
    {
        if (!oneFrameAfterEnableWaited)
            oneFrameAfterEnableWaited = true;

        if (Input.GetKeyDown(KeyCode.Escape) && oneFrameAfterEnableWaited)
        {
            Resume();
        }
    }

    public void Resume()
    {
        GameManager.instance.gameObject.SetActive(true);
        gameObject.SetActive(false);
        GameManager.instance.ContinueGame();
    }

    public void QuitToMenu()
    {
        GameManager.instance.ContinueGame();
        IntersceneData.LoadNextScene("MainMenu");
    }

    public void Quit()
    {
        GameManager.instance.ContinueGame();
        IntersceneData.Quit();
    }
}
