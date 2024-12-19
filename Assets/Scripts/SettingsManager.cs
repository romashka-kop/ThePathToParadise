using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
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

    public enum ActivMenuSetting { MenuControllSettings, MenuGraphicsSettings, MenuSoundSettings, None };
    public static ActivMenuSetting activMenuSetting = ActivMenuSetting.MenuControllSettings;
    public enum ActivPanelSettings { PanelMouseSettings, PanelKeyboardSettings, None };
    public static ActivPanelSettings activPanelSettings = ActivPanelSettings.PanelMouseSettings;

    void Start()
    {
        Init();
    }

    private void Update()
    {
        switch (activMenuSetting)
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
            switch (activPanelSettings)
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
            activPanelSettings = ActivPanelSettings.None;
        }

        if (Input.GetKeyUp(KeyCode.Escape))
            gameObject.SetActive(false);
    }

    private void Init()
    {
        ButtonControll.onClick.AddListener(OpenControllSettings);
        ButtonGraphics.onClick.AddListener(OpenGraphicsSettings);
        ButtonSound.onClick.AddListener(OpenSoundSettings);
        ButtonMouseSettings.onClick.AddListener(OpenMouseSettings);
        ButtonKeyboardSettings.onClick.AddListener(OpenKeyboardSettings);
    }

    private void SwitchMenuSettings(GameObject activPanel, Button activButton)
    {
        Button[] buttons = { ButtonControll, ButtonGraphics, ButtonSound };
        GameObject[] menu = { MenuControllSettings, MenuGraphicsSettings, MenuSoundSettings };
        Vector2 minSize = new Vector2(410, 104);
        Vector2 maxSize = new Vector2(517, 131);

        foreach (Button button in buttons)
        {
            if (activButton == button)
                button.GetComponent<RectTransform>().sizeDelta = maxSize;
            else
                button.GetComponent<RectTransform>().sizeDelta = minSize;
        }

        foreach (GameObject gm in menu)
        {
            if (activPanel == gm)
                gm.SetActive(true);
            else
                gm.SetActive(false);
        }
        activMenuSetting = ActivMenuSetting.None;
    }

    private void SwitchPanelSettings(Button activButton, GameObject activPanel)
    {
        Button[] buttons = {ButtonMouseSettings, ButtonKeyboardSettings };
        GameObject[] panels = {PanelMouseSettings, PanelKeyboardSettings }; 

        foreach (Button button in buttons)
        {
            if(activButton == button)
            {
                button.GetComponent<Image>().color = new Color(1, 1, 1);
            }
            else
            {
                button.GetComponent<Image>().color = new Color(0.5566038f, 0.5566038f, 0.5566038f);
            }
        }
        foreach (GameObject gm in panels)
        {
            if(activPanel == gm)
            {
                gm.SetActive(true);
            }
            else
            {
                gm.SetActive(false);
            }
        }
    }

    private void OpenControllSettings()
    {
        activMenuSetting = ActivMenuSetting.MenuControllSettings;
    }

    private void OpenGraphicsSettings()
    {
        activMenuSetting = ActivMenuSetting.MenuGraphicsSettings;
    }

    private void OpenSoundSettings()
    {
        activMenuSetting = ActivMenuSetting.MenuSoundSettings;
    }

    private void OpenMouseSettings()
    {
        activPanelSettings = ActivPanelSettings.PanelMouseSettings;
    }

    private void OpenKeyboardSettings()
    {
        activPanelSettings = ActivPanelSettings.PanelKeyboardSettings;
    }
}