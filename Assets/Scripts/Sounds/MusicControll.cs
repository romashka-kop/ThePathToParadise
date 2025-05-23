using UnityEngine;

public class MusicControll : MonoBehaviour
{
    private AudioSource _audio;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        _audio.volume = SettingsTransitions.DataSettings.MusicValue;
    }
}
