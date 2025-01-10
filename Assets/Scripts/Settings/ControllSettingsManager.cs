using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ControllSettingsManager : MonoBehaviour
{
    public static float Sensitivity;

    public static bool IsOnVSync;

    public Slider SensitivitySlider;

    public Toggle ToggleIsOnVsync;
    public Toggle ToggleIsOffVsync;

    public static SettingsInputButton[] UserButtons;

    private void Awake()
    {
        Init();
    }

    private void Update()
    {
        SaveUserSettings();
    }

    private void Init()
    {
        MenuManager.DataSettings = (SaveDataSettings)MenuManager.DataSettings.Load(MenuManager.DataSettings, "/SettingsData.json");

        if (SensitivitySlider != null)
            SensitivitySlider.onValueChanged.AddListener(delegate { ValueChangeSensitivitySlider(SensitivitySlider); });

        if (ToggleIsOnVsync != null)
            ToggleIsOnVsync.onValueChanged.AddListener(delegate { ValueChangeIsOnVSync(ToggleIsOnVsync); });

        UserButtons = FindObjectsByType<SettingsInputButton>(FindObjectsSortMode.None);
        Sensitivity = MenuManager.DataSettings.Sensivity;
        IsOnVSync = MenuManager.DataSettings.IsOnVSync;
        ChangeUIComponents();
        ValueChangeIsOnVSync(ToggleIsOnVsync);
    }

    private void SaveUserSettings()
    {
        for (int j = 0; j < MenuManager.DataSettings.PlayerControlKeyCode.Length; j++)
        {
            for (int i = 0; i < UserButtons.Length; i++)
            {
                if ((int)UserButtons[i].direction == j)
                    MenuManager.DataSettings.PlayerControlKeyCode[j] = UserButtons[i].key;
            }
        }
        MenuManager.DataSettings.Save(MenuManager.DataSettings, "/SettingsData.json");
        MenuManager.DataSettings.Sensivity = Sensitivity;
        MenuManager.DataSettings.IsOnVSync = IsOnVSync;
    }

    private void ChangeUIComponents()
    {
        SensitivitySlider.value = Sensitivity;
        ToggleIsOnVsync.isOn = IsOnVSync;

        if (ToggleIsOnVsync.isOn == false)
            ToggleIsOffVsync.isOn = true;

        for (int i = 0; i < UserButtons.Length; i++)
        {
            for (int j = 0; j < MenuManager.DataSettings.PlayerControlKeyCode.Length; j++)
            {
                if ((int)UserButtons[i].direction == j)
                {
                    UserButtons[i].key = MenuManager.DataSettings.PlayerControlKeyCode[j];
                    UserButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = UserButtons[i].key.ToString();
                }
            }
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