using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerSoundControll : MonoBehaviour
{
    private AudioSource _audio;
    public enum StatePlayerAudio {Walk, Jump };
    public static StatePlayerAudio PlayerAudio;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        _audio.volume = SettingsTransitions.DataSettings.PlayerSoundValue;
    }
}
