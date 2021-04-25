using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Scene = UnityEditor.SearchService.Scene;

public class MainMenu : MonoBehaviour
{
    [SerializeField] public int _mainGameSceneName = 0;
    public void ClickPlay()
    {
        SceneManager.LoadScene(_mainGameSceneName);
    }

    public void ClickExit()
    {
        Application.Quit();
    }
}
