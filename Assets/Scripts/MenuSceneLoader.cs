using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneLoader : MonoBehaviour
{
    List<Scene> currentScene = new List<Scene>();

    private void Awake()
    {
        SceneLoader.LoadSceneAdditive(2);
    }
}
