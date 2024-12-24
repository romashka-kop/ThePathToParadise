using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MenuManager : MonoBehaviour
{
    public GameObject PanelSettings;
    public GameObject PanelNewGame;

    public Button ContinueButton;
    public Button NewGameButton;
    public Button SettingsButton;
    public Button QuitButton;

    public static bool IsOpenedSettings = false;
    private static bool _isOpenedNewGame = false;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        ContinueButton.onClick.AddListener(Continue);
        NewGameButton.onClick.AddListener(NewGame);
        SettingsButton.onClick.AddListener(Settings);
        QuitButton.onClick.AddListener(ExitGame);
        PanelSettings.SetActive(IsOpenedSettings);
        PanelNewGame.SetActive(_isOpenedNewGame);
    }

    public void Continue()
    {
        Debug.Log("Продолжить");
    }
    public void NewGame()
    {
        _isOpenedNewGame = !_isOpenedNewGame;
        PanelNewGame.SetActive(_isOpenedNewGame);
    }
    public void Settings()
    {
        IsOpenedSettings = !IsOpenedSettings;
        PanelSettings.SetActive(IsOpenedSettings);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
