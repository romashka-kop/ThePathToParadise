using UnityEngine;
using UnityEngine.UI;

public class SoundSettingsManager : MonoBehaviour
{
    public Slider SliderSound;

    public static float SoundValue;

    private void Start()
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