using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class SettingsTransitions : MonoBehaviour
{
    public Button ButtonControll;
    public Button ButtonGraphics;
    public Button ButtonSound;

    public Button ButtonMouseSettings;
    public Button ButtonKeyboardSettings;

    public GameObject MenuControllSettings;
    public GameObject MenuGraphicsSettings;
    public GameObject MenuSoundSettings;

    public GameObject PanelMouseSettings;
    public GameObject PanelKeyboardSettings;
    public GameObject PanelGraphicsSettings;
    public GameObject PanelSoundSettings;

    private enum ActivMenuSetting { MenuControllSettings, MenuGraphicsSettings, MenuSoundSettings, None };
    private ActivMenuSetting _activMenuSetting = ActivMenuSetting.MenuControllSettings;
    private enum ActivPanelSettings { PanelMouseSettings, PanelKeyboardSettings, None };
    private ActivPanelSettings _activPanelSettings = ActivPanelSettings.PanelMouseSettings;

    public static SaveDataSettings DataSettings = new();

    private Animator _animator;

    void Start()
    {
        DataSettings = DataSettings.Load<SaveDataSettings>(DataSettings, "SettingsData.json");

        Init();
    }

    private void Update()
    {
        switch (_activMenuSetting)
        {
            case ActivMenuSetting.None:
                break;
            case ActivMenuSetting.MenuControllSettings:
                SwitchMenuSettings(MenuControllSettings, ButtonControll);
                break;
            case ActivMenuSetting.MenuGraphicsSettings:
                SwitchMenuSettings(MenuGraphicsSettings, ButtonGraphics);
                break;
            case ActivMenuSetting.MenuSoundSettings:
                SwitchMenuSettings(MenuSoundSettings, ButtonSound);
                break;
        }

        if (MenuControllSettings.activeSelf)
        {
            switch (_activPanelSettings)
            {
                case ActivPanelSettings.None:
                    break;
                case ActivPanelSettings.PanelMouseSettings:
                    SwitchPanelSettings(ButtonMouseSettings, PanelMouseSettings);
                    break;
                case ActivPanelSettings.PanelKeyboardSettings:
                    SwitchPanelSettings(ButtonKeyboardSettings, PanelKeyboardSettings);
                    break;
            }
            _activPanelSettings = ActivPanelSettings.None;
        }

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            SetPanelSettingsDefaultPosition(PanelKeyboardSettings);
            SetPanelSettingsDefaultPosition(PanelGraphicsSettings);
            DataSettings.Save(DataSettings, "SettingsData.json");
            _animator.SetTrigger("CloseSettingsTrigger");
            CloseSeetings();
            MenuManager.IsOpenedSettings = false;
        }
    }

    private void Init()
    {
        _animator = GetComponent<Animator>();
        ButtonControll.onClick.AddListener(OpenControllSettings);
        ButtonGraphics.onClick.AddListener(OpenGraphicsSettings);
        ButtonSound.onClick.AddListener(OpenSoundSettings);
        ButtonMouseSettings.onClick.AddListener(OpenMouseSettings);
        ButtonKeyboardSettings.onClick.AddListener(OpenKeyboardSettings);
    }

    private void SetPanelSettingsDefaultPosition(GameObject panel)
    {
        LimitScrollRect limit = panel.GetComponent<LimitScrollRect>();
        Vector3 panelTransform = panel.transform.localPosition;
        panel.transform.localPosition = new Vector3(panelTransform.x, limit.LimitScrollPositionBottomY, panelTransform.z);
    }

    private async void CloseSeetings()
    {
        await Task.Delay(1000);
        gameObject.SetActive(false);

    }

    private void SwitchMenuSettings(GameObject activPanel, Button activButton)
    {
        Button[] buttons = { ButtonControll, ButtonGraphics, ButtonSound };
        GameObject[] menu = { MenuControllSettings, MenuGraphicsSettings, MenuSoundSettings };
        Vector2 minSize = new Vector2(410, 104);
        Vector2 maxSize = new Vector2(517, 131);

        foreach (Button button in buttons)
            button.GetComponent<RectTransform>().sizeDelta = activButton == button ? maxSize : minSize;

        foreach (GameObject gm in menu)
            gm.SetActive(activPanel == gm);

        _activMenuSetting = ActivMenuSetting.None;
    }

    private void SwitchPanelSettings(Button activButton, GameObject activPanel)
    {
        Button[] buttons = { ButtonMouseSettings, ButtonKeyboardSettings };
        GameObject[] panels = { PanelMouseSettings, PanelKeyboardSettings };

        foreach (Button button in buttons)
            button.GetComponent<Image>().color = activButton == button ? new Color(1, 1, 1) : new Color(0.5566038f, 0.5566038f, 0.5566038f);

        foreach (GameObject gm in panels)
            gm.SetActive(activPanel == gm);
    }

    private void OpenControllSettings()
    {
        _activMenuSetting = ActivMenuSetting.MenuControllSettings;
    }

    private void OpenGraphicsSettings()
    {
        _activMenuSetting = ActivMenuSetting.MenuGraphicsSettings;
    }

    private void OpenSoundSettings()
    {
        _activMenuSetting = ActivMenuSetting.MenuSoundSettings;
    }

    private void OpenMouseSettings()
    {
        _activPanelSettings = ActivPanelSettings.PanelMouseSettings;
    }

    private void OpenKeyboardSettings()
    {
        _activPanelSettings = ActivPanelSettings.PanelKeyboardSettings;
    }
}