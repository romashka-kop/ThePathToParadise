using UnityEngine;
using UnityEngine.UI;

public class SoundSettingsManager : MonoBehaviour
{
    public Slider SliderSound;

    public static float SoundValue;

    private void Awake()
    {
        if (SliderSound != null)
            SliderSound.onValueChanged.AddListener(delegate { SliderSoundChange(SliderSound); });

        ChangeUIComponents();
    }

    private void Update()
    {
        SaveDataSoundSettings();
    }

    private void SaveDataSoundSettings()
    {
        MenuManager.DataSettings.MusicValue = SoundValue;
        MenuManager.DataSettings.Save(MenuManager.DataSettings, "SettingsData.json");
    }

    private void ChangeUIComponents()
    {
        MenuManager.DataSettings = (SaveDataSettings)MenuManager.DataSettings.Load("SettingsData.json");
        SoundValue = MenuManager.DataSettings.MusicValue;
        SliderSound.value = SoundValue;
    }

    private void SliderSoundChange(Slider slider)
    {
        SoundValue = slider.value;
    }
}
