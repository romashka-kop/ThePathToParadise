using UnityEngine;
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

    private const string _urlRoma = "https://vk.com/romashkaaaa_a";
    private const string _urlKirill = "https://web.telegram.org/a/#-1001617083906";
    private SaveDataScene _dataScene = new();

    void Start()
    {
        Init();
    }

    private void Init()
    {
        _dataScene = _dataScene.Load<SaveDataScene>(_dataScene, "SceneData.json");
        SettingsTransitions.DataSettings = SettingsTransitions.DataSettings.Load<SaveDataSettings>(SettingsTransitions.DataSettings, "SettingsData.json");
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
        LoadingManager.SwitchSceneLoading(_dataScene.IndexLvl);
    }
    public void NewGame()
    {
        _dataScene.IndexLvl = 1;
        LoadingManager.SwitchSceneLoading(_dataScene.IndexLvl);
    }
    public void Settings()
    {
        IsOpenedSettings = !IsOpenedSettings;
        CanvasSettings.SetActive(IsOpenedSettings);
        Animator anim = CanvasSettings.GetComponent<Animator>();
        anim.SetTrigger("OpenSettingsTrigger");
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
        if (_dataScene.IndexLvl == 0)
        {
            ContinueButton.enabled = false;
            colorBlock.normalColor = new Color(0.5921569f, 0.5921569f, 0.5921569f, 0.5f);
            ContinueButton.GetComponent<Image>().color = new Color(0,0,0,1);
        }
        else
        {
            ContinueButton.enabled = true;
            colorBlock.normalColor = new Color(0.2078f, 0.2078f, 0.2078f, 1f);
            ContinueButton.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        }
        ContinueButton.colors = colorBlock;
    }
}
