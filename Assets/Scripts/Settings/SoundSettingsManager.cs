using UnityEngine;
using UnityEngine.UI;

public class SoundSettingsManager : MonoBehaviour
{
    public Slider SliderSound;

    private void Awake()
    {
        if (SliderSound != null)
            SliderSound.onValueChanged.AddListener(delegate { SliderSoundChange(SliderSound); });
    }

    private void SliderSoundChange(Slider slider)
    {
        //////////////
    }
}
