using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadingScene : MonoBehaviour
{
    public float minLoadingTime;

    

    void Start()
    {
        StartCoroutine(LoadScene());
    }

    public float currentLoadingTime = 0f;

    IEnumerator LoadScene()
    {
        yield return null;
        if(IntersceneData.exit)
        {
            while(currentLoadingTime < minLoadingTime)
            {
                yield return new WaitForEndOfFrame();
                currentLoadingTime += Time.deltaTime;
            }
            Application.Quit();
        }

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(IntersceneData.sceneToLoad);
        asyncOperation.allowSceneActivation = false;
        while(asyncOperation.progress < 0.9f || currentLoadingTime < minLoadingTime)
        {
            yield return new WaitForEndOfFrame();
            currentLoadingTime += Time.deltaTime;
        }

        asyncOperation.allowSceneActivation = true;
    }
}
