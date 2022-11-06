using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class AsyncLoading : MonoBehaviour
{
    //비동기 로딩씬
    public static string nextScene;

    public RenderPipelineAsset urpAsset;

    void Start()
    {
        Time.timeScale = 1f;
        StartCoroutine(LoadScene());
    }

    public static void LoadScene(string sceneName)
    {
        nextScene = sceneName;
        SceneManager.LoadScene("Loading");
    }

    IEnumerator LoadScene()
    {
        yield return null;
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = false;

        while (!op.isDone)
        {
            yield return null;
            if (op.progress >= 0.9f)
            {
                GraphicsSettings.renderPipelineAsset = urpAsset;
                op.allowSceneActivation = true;
                yield break;
            }
        }
    }
}
