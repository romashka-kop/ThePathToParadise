using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class SaveDataSettings : AbsSaveData
{
    #region ��������� �������
    public int[] graphicIndexSettings = { 2, 2, 1, 1, 2, 2 };
    #endregion

    #region ��������� ����������
    public KeyCode[] PlayerControlKeyCode = {KeyCode.W, KeyCode.S, KeyCode.A, KeyCode.D, KeyCode.Space, KeyCode.LeftControl};

    public bool IsOnVSync = false;
    public float Sensivity = 300f;
    #endregion

    #region ��������� ������
    public float MusicValue = 50f;
    #endregion

    public SaveDataSettings(string path)
    {
        Load<SaveDataSettings>(this, path);
    }
}
