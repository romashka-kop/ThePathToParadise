using UnityEngine;
using UnityEngine.Audio;

public class MenuSound : MonoBehaviour
{
    private AudioSource _audio;

    void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        _audio.volume = SettingsTransitions.DataSettings.MusicValue;
    }

    public void ClickButton()
    {
        _audio.Play();
    }
}
