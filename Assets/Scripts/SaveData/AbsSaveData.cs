using System;
using System.IO;
using TMPro;
using UnityEngine;

public abstract class AbsSaveData
{
    private readonly string _documentDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ThePathToParadise");

    public void Save(AbsSaveData data, string filePathJSON)
    {
        if (!Directory.Exists(_documentDirectory))
            Directory.CreateDirectory(_documentDirectory);
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Path.Combine(_documentDirectory, filePathJSON), json);
    }

    public ResData Load<ResData>(AbsSaveData data, string filePathJSON)
    {
        if (File.Exists(Path.Combine(_documentDirectory, filePathJSON)))
        {
            string json = File.ReadAllText(Path.Combine(_documentDirectory, filePathJSON));
            return JsonUtility.FromJson<ResData>(json);
        }
        else
        {
            Save(data, filePathJSON);
            return Load<ResData>(data, filePathJSON);
        }
    }
}
