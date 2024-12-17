using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MenuManager : MonoBehaviour
{
    public GameObject PanelSettings;
    public GameObject PanelNewGame;

    private static bool _isOpenedSettings = false;

    public void Continue()
    {
        SceneManager.LoadScene("");
    }
    public void NewGame()
    {
        SceneManager.LoadScene("");
    }
    public void Settings()
    {
        _isOpenedSettings = !_isOpenedSettings;
        PanelSettings.SetActive(_isOpenedSettings);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
