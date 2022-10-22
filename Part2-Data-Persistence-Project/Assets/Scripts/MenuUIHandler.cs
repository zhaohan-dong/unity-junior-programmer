using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public GameObject PlayerName;
    public GameObject BestScore;

    public void Awake()
    {
        
    }


    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void SetName()
    {
        MainManager.Instance.SetPlayerName(PlayerName.GetComponent<TMP_InputField>().text);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
