using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class SaveDataSettings : IData
{
    #region Настройки Графики
    public int[] graphicIndexSettings = { 2, 2, 1, 1, 2, 2 };
    #endregion

    #region Настройки Управления
    public KeyCode[] PlayerControlKeyCode = {KeyCode.W, KeyCode.S, KeyCode.A, KeyCode.D, KeyCode.Space, KeyCode.LeftControl};

    public bool IsOnVSync = true;
    public float Sensivity = 30f;
    #endregion

    #region Настройки Звуков
    public float MusicValue = 50f;
    #endregion

    public void Save(IData data, string path)
    {
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + path, json);
    }

    public IData Load(string path)
    {
        if (File.Exists(Application.persistentDataPath + path))
        {
            string json = File.ReadAllText(Application.persistentDataPath + path);
            return JsonUtility.FromJson<SaveDataSettings>(json);
        }
        else
        {
            Save(this, path);
            Load(path);
            return null;
        }
    }
}
