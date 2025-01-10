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

    public IData Load(IData data, string path)
    {
        if (File.Exists(Application.persistentDataPath + path))
        {
            string json = File.ReadAllText(Application.persistentDataPath + path);
            return JsonUtility.FromJson<SaveDataScene>(json);
        }
        else
        {
            Save(data, path);
            return Load(data, path);  
        }
    }
}
