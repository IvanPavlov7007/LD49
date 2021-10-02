using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public string sceneToLoad;

    private void Awake()
    {
    }
    public void StartGame()
    {
        IntersceneData.LoadNextScene(sceneToLoad);
    }

    public void Quit()
    {
        IntersceneData.Quit();
    }
}
