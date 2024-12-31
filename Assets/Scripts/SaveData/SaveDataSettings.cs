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
    //public KeyCode[] PlayerControlKeyCode = {KeyCode.W, KeyCode.S, KeyCode.A, KeyCode.D, KeyCode.Space, KeyCode.LeftControl};

    public Dictionary<SettingsInputButton.MoveDirection,KeyCode> PlayerControlKeyCode = new Dictionary<SettingsInputButton.MoveDirection, KeyCode>()
    {
        {SettingsInputButton.MoveDirection.Forward, KeyCode.W },
        {SettingsInputButton.MoveDirection.Back, KeyCode.S },
        {SettingsInputButton.MoveDirection.Left, KeyCode.A },
        {SettingsInputButton.MoveDirection.Right, KeyCode.D },
        {SettingsInputButton.MoveDirection.Jump, KeyCode.Space },
        {SettingsInputButton.MoveDirection.Squat, KeyCode.LeftControl },
    };

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
        Debug.Log("Данные сохранены");
    }

    public IData Load(string path)
    {
        if (File.Exists(Application.persistentDataPath + path))
        {
            string json = File.ReadAllText(Application.persistentDataPath + path);
            Debug.Log("Данные загружены");
            return JsonUtility.FromJson<SaveDataSettings>(json);
        }
        else
        {
            Save(this, path);
            return null;
        }
    }
}
