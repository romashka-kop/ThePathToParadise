using UnityEngine;

[System.Serializable]
public class SaveDataSettings : AbsSaveData
{
    #region ��������� �������
    public int[] graphicIndexSettings = { 0, 0, 0, 2, 1, 1, 2, 2 };
    #endregion

    #region ��������� ����������
    public KeyCode[] PlayerControlKeyCode = { KeyCode.W, KeyCode.S, KeyCode.A, KeyCode.D, KeyCode.Space, KeyCode.LeftShift };

    public bool IsOnVSync = false;
    public float Sensivity = 300f;
    #endregion

    #region ��������� ������
    public float MusicValue = 50f;
    #endregion
}
