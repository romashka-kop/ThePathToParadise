using System.IO;
using UnityEngine;

public abstract class AbsSaveData
{
    public void Save(AbsSaveData data, string path)
    {
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + path, json);
    }

    public ResData Load <ResData>(AbsSaveData data, string path)
    {
        if (File.Exists(Application.persistentDataPath + path))
        {
            string json = File.ReadAllText(Application.persistentDataPath + path);
            return JsonUtility.FromJson<ResData>(json);
        }
        else
        {
            Save(data, path);
            return Load<ResData>(data, path);
        }
    }
}
