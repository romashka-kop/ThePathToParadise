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

    private void ChangeUIComponents()
    {
        MenuManager.DataSettings = (SaveDataSettings)MenuManager.DataSettings.Load(MenuManager.DataSettings,"SettingsData.json");
        SoundValue = MenuManager.DataSettings.MusicValue;
        SliderSound.value = SoundValue;
    }

    private void SliderSoundChange(Slider slider)
    {
        SoundValue = slider.value;
    }
}
