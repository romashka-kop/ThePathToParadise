using TMPro;
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

    public static SaveDataSettings DataSettings = new();
    public static SaveDataPlayer DataPlayer = new();
    public static SaveDataScene DataScene = new();

    void Awake()
    {
        Init();
    }

    private void Init()
    {
        DataSettings = (SaveDataSettings)DataSettings.Load("/SettingsData.json");

        DataPlayer = (SaveDataPlayer)DataPlayer.Load("/PlayerData.json");

        DataScene = (SaveDataScene)DataScene.Load("/SceneData.json");

        ContinueButton.onClick.AddListener(Continue);
        NewGameButton.onClick.AddListener(NewGame);
        SettingsButton.onClick.AddListener(Settings);
        QuitButton.onClick.AddListener(ExitGame);
        CanvasSettings.SetActive(IsOpenedSettings);
        CanvasNewGame.SetActive(_isOpenedNewGame);

        if(DataScene.IndexLvl == 0)
            ContinueButton.enabled = false;
        else
            ContinueButton.enabled = true;
    }

    public void Continue()
    {
       /////////
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
