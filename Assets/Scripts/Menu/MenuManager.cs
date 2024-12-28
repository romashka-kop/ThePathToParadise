using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MenuManager : MonoBehaviour
{
    public GameObject CanvasSettings;
    public GameObject CanvasNewGame;

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
        CanvasSettings.SetActive(IsOpenedSettings);
        CanvasNewGame.SetActive(_isOpenedNewGame);
    }

    public void Continue()
    {
        /////////////////////////
    }
    public void NewGame()
    {
        _isOpenedNewGame = !_isOpenedNewGame;
        CanvasNewGame.SetActive(_isOpenedNewGame);
    }
    public void Settings()
    {
        IsOpenedSettings = !IsOpenedSettings;
        CanvasSettings.SetActive(IsOpenedSettings);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
