using UnityEngine;
using UnityEngine.UI;

public class ControllSettingsManager : MonoBehaviour
{
    public static float Sensitivity;

    public static bool IsInversionY;
    public static bool IsOnVSync;


    public Slider SensitivitySlider;

    public Toggle ToggleIsOnInversion;
    public Toggle ToggleIsOnVsync;

    public static SettingsInputButton[] usersButton;

    private void Start()
    {
        Init();
        SearchAllUSerButton();
    }

    private void Init()
    {
        if (SensitivitySlider != null)
            SensitivitySlider.onValueChanged.AddListener(delegate { ValueChangeSensitivitySlider(SensitivitySlider); });

        if (ToggleIsOnInversion != null)
            ToggleIsOnInversion.onValueChanged.AddListener(delegate { ValueChangeIsOnInversion(ToggleIsOnInversion); });

        if(ToggleIsOnVsync != null)
            ToggleIsOnVsync.onValueChanged.AddListener(delegate {ValueChangeIsOnVSync(ToggleIsOnVsync); });

        Sensitivity = SensitivitySlider.value;
        IsInversionY = ToggleIsOnInversion.isOn;
        IsOnVSync = ToggleIsOnVsync.isOn;
    }

    private void SearchAllUSerButton()///////закончить
    {

    }

    private void ValueChangeSensitivitySlider(Slider slider)
    {
        Sensitivity = slider.value;
        Debug.Log(Sensitivity);
    }

    private void ValueChangeIsOnInversion(Toggle toggle)
    {
        IsInversionY = toggle.isOn;
        Debug.Log(IsInversionY);
    }

    private void ValueChangeIsOnVSync(Toggle toggle)
    {
        IsOnVSync = toggle.isOn;
        Debug.Log(IsOnVSync);
    }
}
