using UnityEngine;
using UnityEngine.UI;

public class ControllSettingsManager : MonoBehaviour
{
    public static float Sensitivity;

    public static bool IsOnVSync;


    public Slider SensitivitySlider;

    public Toggle ToggleIsOnVsync;

    public static SettingsInputButton[] UsersButton;

    private void Awake()
    {
        Init();
        SearchAllUSerButton();
    }

    private void Init()
    {
        if (SensitivitySlider != null)
            SensitivitySlider.onValueChanged.AddListener(delegate { ValueChangeSensitivitySlider(SensitivitySlider); });

        if(ToggleIsOnVsync != null)
            ToggleIsOnVsync.onValueChanged.AddListener(delegate {ValueChangeIsOnVSync(ToggleIsOnVsync); });

        Sensitivity = SensitivitySlider.value;
        IsOnVSync = ToggleIsOnVsync.isOn;
    }

    private void SearchAllUSerButton()
    {
        UsersButton = FindObjectsByType<SettingsInputButton>(FindObjectsSortMode.None);
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
