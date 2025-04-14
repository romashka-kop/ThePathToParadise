using UnityEngine;

[System.Serializable]
public class SaveDataSettings : AbsSaveData
{
    #region Настройки Графики
    public int[] graphicIndexSettings = { 0, 0, 0, 2, 1, 1, 2, 2 };
    #endregion

    #region Настройки Управления
    public KeyCode[] PlayerControlKeyCode = { KeyCode.W, KeyCode.S, KeyCode.A, KeyCode.D, KeyCode.Space, KeyCode.LeftShift };

    public bool IsOnVSync = false;
    public float Sensivity = 300f;
    #endregion

    #region Настройки Звуков
    public float MusicValue = 50f;
    #endregion
}
