using UnityEngine;
using UnityEngine.UI;

public class SoundSettingsManager : MonoBehaviour
{
    [SerializeField] private Slider _sliderMenuSound;
    [SerializeField] private Slider _sliderSound;
    [SerializeField] private Slider _sliderEffectSound;
    [SerializeField] private Slider _sliderPlayerSound;

    private void Start()
    {
        if (_sliderMenuSound != null)
            _sliderMenuSound.onValueChanged.AddListener(delegate { SliderMenuSoundChange(_sliderMenuSound); });

        if (_sliderSound != null)
            _sliderSound.onValueChanged.AddListener(delegate { SliderSoundChange(_sliderSound); });

        if (_sliderEffectSound != null)
            _sliderEffectSound.onValueChanged.AddListener(delegate { SliderEffectSoundChange(_sliderEffectSound); });

        if (_sliderPlayerSound != null)
            _sliderPlayerSound.onValueChanged.AddListener(delegate { SliderPlayerSoundChange(_sliderPlayerSound); });

        ChangeUIComponents();
    }

    private void Update()
    {
        SaveDataSoundSettings();
    }

    private void SaveDataSoundSettings()
    {
        SettingsTransitions.DataSettings.MenuSoundValue = _sliderMenuSound.value;
        SettingsTransitions.DataSettings.MusicValue = _sliderSound.value;
        SettingsTransitions.DataSettings.EffectSoundValue = _sliderEffectSound.value;
        SettingsTransitions.DataSettings.PlayerSoundValue = _sliderPlayerSound.value;
    }

    private void ChangeUIComponents()
    {
        _sliderMenuSound.value = SettingsTransitions.DataSettings.MenuSoundValue;
        _sliderSound.value = SettingsTransitions.DataSettings.MusicValue;
        _sliderEffectSound.value = SettingsTransitions.DataSettings.EffectSoundValue;
        _sliderPlayerSound.value = SettingsTransitions.DataSettings.PlayerSoundValue;
    }

    private void SliderMenuSoundChange(Slider slider)
    {
        SettingsTransitions.DataSettings.MenuSoundValue = slider.value;
    }

    private void SliderSoundChange(Slider slider)
    {
        SettingsTransitions.DataSettings.MusicValue = slider.value;
    }

    private void SliderEffectSoundChange(Slider slider)
    {
        SettingsTransitions.DataSettings.EffectSoundValue = slider.value;
    }

    private void SliderPlayerSoundChange(Slider slider)
    {
        SettingsTransitions.DataSettings.PlayerSoundValue = slider.value;
    }
}