using TMPro;
using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class ControllSettingsManager : MonoBehaviour
{
    public static float Sensitivity;

    public static bool IsOnVSync;

    public Slider SensitivitySlider;

    public Toggle ToggleIsOnVsync;

    public static SettingsInputButton[] UserButtons;

    public TextMeshProUGUI[] UserButtonsText;

    private void Awake()
    {
        Init();
    }

    private void Update()
    {
        SaveUserButton();
    }

    private void Init()
    {
        MenuManager.DataSettings = (SaveDataSettings)MenuManager.DataSettings.Load("/SettingsData.json");

        if (SensitivitySlider != null)
            SensitivitySlider.onValueChanged.AddListener(delegate { ValueChangeSensitivitySlider(SensitivitySlider); });

        if (ToggleIsOnVsync != null)
            ToggleIsOnVsync.onValueChanged.AddListener(delegate { ValueChangeIsOnVSync(ToggleIsOnVsync); });

        UserButtons = FindObjectsByType<SettingsInputButton>(FindObjectsSortMode.None);
        Sensitivity = MenuManager.DataSettings.Sensivity;
        IsOnVSync = MenuManager.DataSettings.IsOnVSync;
        ChangeUIComponents();
    }

    private void SaveUserButton()
    {
        for (int i = 0; i < MenuManager.DataSettings.PlayerControlKeyCode.Count; i++)
        {
            foreach (var button in UserButtons)
            {
                if (button.direction == MenuManager.DataSettings.PlayerControlKeyCode.ElementAt(i).Key)
                {
                    MenuManager.DataSettings.PlayerControlKeyCode.Remove(MenuManager.DataSettings.PlayerControlKeyCode.ElementAt(i).Key);
                    MenuManager.DataSettings.PlayerControlKeyCode.Add(button.direction, button.key);
                }
            }
        }
        MenuManager.DataSettings.Save(MenuManager.DataSettings, "/SettingsData.json");
    }

    private void ChangeUIComponents()
    {
        SensitivitySlider.value = Sensitivity;
        ToggleIsOnVsync.isOn = IsOnVSync;

        for (int i = 0; i < UserButtons.Length; i++)
        {
            foreach (var keys in MenuManager.DataSettings.PlayerControlKeyCode)
            {
                if (UserButtons[i].direction == keys.Key)
                    UserButtons[i].key = keys.Value;
            }
            UserButtons[i].gameObject.transform.GetComponentInChildren<TextMeshProUGUI>().text = UserButtons[i].key.ToString();
        }
    }

    private void ValueChangeSensitivitySlider(Slider slider)
    {
        Sensitivity = slider.value;
    }

    private void ValueChangeIsOnVSync(Toggle toggle)
    {
        IsOnVSync = toggle.isOn;
        QualitySettings.vSyncCount = IsOnVSync ? 1 : 0;
    }
}
