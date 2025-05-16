using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerSoundControll : MonoBehaviour
{
    [SerializeField] private AudioClip _walkClip;
    [SerializeField ]private AudioSource _audioBody;
    [SerializeField ]private AudioSource _audioCamera;

    void Update()
    {
        _audioBody.volume = SettingsTransitions.DataSettings.PlayerSoundValue;
        _audioCamera.volume = SettingsTransitions.DataSettings.PlayerSoundValue;
    }

    public void PlayFootSteps()
    {
        if (!_audioBody.isPlaying)
            _audioBody.Play();
    }

    public void StopFootSteps()
    {
        if (_audioBody.isPlaying)
            _audioBody.Stop();
    }

}
