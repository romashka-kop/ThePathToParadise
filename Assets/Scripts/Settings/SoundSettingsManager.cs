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
        SettingsTransitions.DataSettings.MusicValue = SoundValue;
        SettingsTransitions.DataSettings.Save(SettingsTransitions.DataSettings, "SettingsData.json");
    }

    private void ChangeUIComponents()
    {
        SoundValue = SettingsTransitions.DataSettings.MusicValue;
        SliderSound.value = SoundValue;
    }

    private void SliderSoundChange(Slider slider)
    {
        SoundValue = slider.value;
    }
}