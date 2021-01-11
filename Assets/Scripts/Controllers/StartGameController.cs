using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class StartGameController : MonoBehaviour
{
    public Button b_NewGame;
    public Button b_ExitGame;

    private void Awake()
    {
        if(b_ExitGame != null)
        {
            b_ExitGame.onClick.AddListener(delegate { CloseGame(); });
        }

        if(b_NewGame != null)
        {
            b_NewGame.onClick.AddListener(delegate { StartNewGame(); });
        }
    }

    public void StartNewGame()
    {
        SceneLoader.LoadScene("MainGameMenu");
    }

    private void CloseGame()
    {
        Application.Quit();

#if UNITY_EDITOR
        Debug.Log("Close game");
#endif
    }
}
