using System.IO;
using System;
using System.Threading.Tasks;
using TMPro;
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

    [SerializeField] Image _uploadGraphicImage;
    public static bool IsOpenedSettings = false;
    public static bool IsUploadGraphics = false;

    private bool _isLvl = true;


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

        if (IsUploadGraphics == false)
            UploadingGraphics();

        CheckSaveGame();
    }

    public void Continue()
    {
        if (_isLvl)
        {
            _isLvl = false;
            LoadingManager.SwitchSceneLoading(15);
        }
    }

    public void NewGame()
    {
        if (_isLvl)
        {
            _isLvl = false;
            _dataScene.IndexLvl = 1;
            _dataScene.Calculate();
            _dataScene.Save(_dataScene, "SceneData.json");
            LoadingManager.SwitchSceneLoading(15);
        }
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

    private async void UploadingGraphics()
    {
        CanvasSettings.SetActive(true);
        _uploadGraphicImage.gameObject.SetActive(true);

        await Task.Delay(2000);

        if (IsUploadGraphics)
        {
            _uploadGraphicImage.gameObject.SetActive(false);
            CanvasSettings.SetActive(false);
        }
        else UploadingGraphics();

    }

    private void CheckSaveGame()
    {
        ColorBlock colorBlock = ContinueButton.colors;
        if (_dataScene.IndexLvl == 0)
        {
            ContinueButton.enabled = false;
            colorBlock.normalColor = new Color(0.5921569f, 0.5921569f, 0.5921569f, 0.5f);
            ContinueButton.GetComponent<Image>().color = new Color(0, 0, 0, 1);
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
