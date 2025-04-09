using UnityEngine;
using UnityEngine.UI;

public class SoundSettingsManager : MonoBehaviour
{
    public Slider SliderSound;

    public static float SoundValue;

    private SaveDataSettings _dataSettings;

    private void Awake()
    {
        _dataSettings = new("SettingsData.json");
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
        _dataSettings.MusicValue = SoundValue;
        _dataSettings.Save(_dataSettings, "SettingsData.json");
    }

    private void ChangeUIComponents()
    {
        _dataSettings = _dataSettings.Load<SaveDataSettings>(_dataSettings, "SettingsData.json");
        SoundValue = _dataSettings.MusicValue;
        SliderSound.value = SoundValue;
    }

    private void SliderSoundChange(Slider slider)
    {
        SoundValue = slider.value;
    }
}