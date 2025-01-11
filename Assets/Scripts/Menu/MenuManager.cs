using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MenuManager : MonoBehaviour
{
    public GameObject CanvasSettings;

    public Button ContinueButton;
    public Button NewGameButton;
    public Button SettingsButton;
    public Button QuitButton;
    public Button ToKirill;
    public Button ToRoma;

    public static bool IsOpenedSettings = false;

    public static SaveDataSettings DataSettings = new();
    public static SaveDataPlayer DataPlayer = new();
    public static SaveDataScene DataScene = new();

    private readonly string _urlRoma = "https://vk.com/romashkaaaa_a";
    private readonly string _urlKirill = "https://web.telegram.org/a/#-1001617083906";

    void Awake()
    {
        Init();
    }

    private void Init()
    {
        DataSettings = (SaveDataSettings)DataSettings.Load(DataSettings, "/SettingsData.json");

        DataPlayer = (SaveDataPlayer)DataPlayer.Load(DataPlayer, "/PlayerData.json");

        DataScene = (SaveDataScene)DataScene.Load(DataScene, "/SceneData.json");

        ContinueButton.onClick.AddListener(Continue);
        NewGameButton.onClick.AddListener(NewGame);
        SettingsButton.onClick.AddListener(Settings);
        QuitButton.onClick.AddListener(ExitGame);
        ToRoma.onClick.AddListener(ClickToRoma);
        ToKirill.onClick.AddListener(ClickToKirill);
        CanvasSettings.SetActive(IsOpenedSettings);

        CheckSaveGame();
    }

    public void Continue()
    {
        SceneManager.LoadScene(DataScene.IndexLvl);
    }
    public void NewGame()
    {
        DataScene.IndexLvl = 1;
        SceneManager.LoadScene("LoadingScene");
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

    private void ClickToRoma()
    {
        Application.OpenURL(_urlRoma);
    }

    private void ClickToKirill()
    {
        Application.OpenURL(_urlKirill);
    }

    private void CheckSaveGame()
    {
        ColorBlock colorBlock = ContinueButton.colors;
        if (DataScene.IndexLvl == 0)
        {
            ContinueButton.enabled = false;
            colorBlock.normalColor = new Color(0.5921569f, 0.5921569f, 0.5921569f, 0.5f);
        }
        else
        {
            ContinueButton.enabled = true;
            colorBlock.normalColor = new Color(0.5921569f, 0.5921569f, 0.5921569f, 1f);
        }
        ContinueButton.colors = colorBlock;
    }
}
