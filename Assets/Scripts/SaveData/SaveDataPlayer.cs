using UnityEngine;
using System.IO;

[System.Serializable]
public class SaveDataPlayer : IData
{
    public Vector3 PlayerPosition = new Vector3(0,0,0);
    public Vector3 PlayerRotation = new Vector3(0,0,0);

    //public Tool ActivTool;

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
            return JsonUtility.FromJson<SaveDataPlayer>(json);
        }
        else
        {
            Save(data, path);
            return Load(data, path);
        }
    }
}
