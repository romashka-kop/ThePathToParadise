using System.IO;
using UnityEngine;

[System.Serializable]
public class SaveDataScene : IData
{
    public int IndexLvl = 0;

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
            Debug.Log("Данные загружены");
            return JsonUtility.FromJson<SaveDataScene>(json);
        }
        else
        {
            Save(this, path);
            return null;
        }
    }
}
