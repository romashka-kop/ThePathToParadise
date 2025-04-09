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

    private SaveDataSettings _dataSettings;

    private void Awake()
    {
        _dataSettings = new("SettingsData.json");
        Init();
    }

    private void Update()
    {
        SaveUserSettings();
    }

    private void Init()
    {
        _dataSettings = _dataSettings.Load<SaveDataSettings>(_dataSettings, "SettingsData.json");

        if (SensitivitySlider != null)
            SensitivitySlider.onValueChanged.AddListener(delegate { ValueChangeSensitivitySlider(SensitivitySlider); });

        if (ToggleIsOnVsync != null)
            ToggleIsOnVsync.onValueChanged.AddListener(delegate { ValueChangeIsOnVSync(ToggleIsOnVsync); });

        UserButtons = FindObjectsByType<SettingsInputButton>(FindObjectsSortMode.None);
        Sensitivity = _dataSettings.Sensivity;
        IsOnVSync = _dataSettings.IsOnVSync;
        ChangeUIComponents();
        ValueChangeIsOnVSync(ToggleIsOnVsync);
    }

    public void SaveUserSettings()
    {
        for (int j = 0; j < _dataSettings.PlayerControlKeyCode.Length; j++)
        {
            for (int i = 0; i < UserButtons.Length; i++)
            {
                if ((int)UserButtons[i].direction == j)
                    _dataSettings.PlayerControlKeyCode[j] = UserButtons[i].key;
            }
        }
        _dataSettings.Sensivity = Sensitivity;
        _dataSettings.IsOnVSync = IsOnVSync;
        _dataSettings.Save(_dataSettings, "SettingsData.json");
    }

    private void ChangeUIComponents()
    {
        SensitivitySlider.value = Sensitivity;
        ToggleIsOnVsync.isOn = IsOnVSync;

        if (ToggleIsOnVsync.isOn == false)
            ToggleIsOffVsync.isOn = true;

        for (int i = 0; i < UserButtons.Length; i++)
        {
            for (int j = 0; j < _dataSettings.PlayerControlKeyCode.Length; j++)
            {
                if ((int)UserButtons[i].direction == j)
                {
                    UserButtons[i].key = _dataSettings.PlayerControlKeyCode[j];
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