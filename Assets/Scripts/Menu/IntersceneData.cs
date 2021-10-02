using UnityEngine.SceneManagement;

public static class IntersceneData
{
    public static string sceneToLoad = "MainMenu";
    public static bool exit = false;

    //Game settings, for example:
    public static bool _this, _that;
    public static float _those;

    public static void LoadNextScene(string scene)
    {
        sceneToLoad = scene;
        SceneManager.LoadScene("LoadingScene");
    }

    public static void Quit()
    {
        exit = true;
        SceneManager.LoadScene("LoadingScene");
    }
}
