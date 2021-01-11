using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    private static SceneLoader instance;

    private void Awake()
    {
        instance = this;
    }

    public static void LoadScene(int sceneIndex, float delay = 0)
    {
        instance.StartCoroutine(LoadSceneAsync(sceneIndex, delay));
    }

    public static void LoadScene(string sceneName, float delay = 0)
    {
        instance.StartCoroutine(LoadSceneAsync(sceneName, delay));
    }

    public static void LoadSceneAdditive(int sceneIndex, float delay = 0)
    {
        instance.StartCoroutine(LoadSceneAsyncAdditive(sceneIndex, delay));
    }

    public static void LoadSceneAdditive(string sceneName, float delay = 0)
    {
        instance.StartCoroutine(LoadSceneAsyncAdditive(sceneName, delay));
    }

    public static void RestartScene(float delay = 0)
    {
        var sceneIndex = SceneManager.GetActiveScene().buildIndex;
        instance.StartCoroutine(LoadSceneAsync(sceneIndex, delay));
    }

    private static IEnumerator LoadSceneAsync(int sceneIndex, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadSceneAsync(sceneIndex);
    }

    private static IEnumerator LoadSceneAsync(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadSceneAsync(sceneName);
    }

    private static IEnumerator LoadSceneAsyncAdditive(int sceneIndex, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Additive);
    }

    private static IEnumerator LoadSceneAsyncAdditive(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
    }
}
