using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class EffectSoundControll : MonoBehaviour
{
    private AudioSource _audio;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        _audio.volume = SettingsTransitions.DataSettings.EffectSoundValue;
    }
}
