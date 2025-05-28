using UnityEngine;

[System.Serializable]
public class SaveDataSettings : AbsSaveData
{
    #region Настройки Графики
    public int[] graphicIndexSettings = { 0, 1, 0, 2, 1, 1, 2, 2 };
    #endregion

    #region Настройки Управления
    public KeyCode[] PlayerControlKeyCode = { KeyCode.W, KeyCode.S, KeyCode.A, KeyCode.D, KeyCode.Space,KeyCode.LeftShift, KeyCode.LeftControl, KeyCode.E, KeyCode.Mouse0 , KeyCode.Q, KeyCode.Mouse1};

    public bool IsOnVSync = false;
    public float Sensivity = 300f;
    #endregion

    #region Настройки Звуков
    public float MenuSoundValue = 0.5f;
    public float MusicValue = 0.5f;
    public float MusicGameValue = 0.5f;
    public float EffectSoundValue = 0.5f;
    public float PlayerSoundValue = 0.5f;
    #endregion
}
