using UnityEngine;

public class MusicGameControll : MonoBehaviour
{
    public static AudioSource Audio;

    private void Start()
    {
        Audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        Audio.volume = SettingsTransitions.DataSettings.MusicGameValue;
    }
}
