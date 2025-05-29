using System;
using System.IO;
using TMPro;
using UnityEngine;

public abstract class AbsSaveData
{
    private readonly string _documentDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ThePathToParadise");

    string _storyPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "The Path To Paradise_Data", "StreamingAssets");


    public void Save(AbsSaveData data, string filePathJSON)
    {
        if (data.GetType() == typeof(StoryCollection))
        {
            SaveData(filePathJSON, data, _storyPath);
        }
        else
        {
            if (!Directory.Exists(_documentDirectory))
                Directory.CreateDirectory(_documentDirectory);
            SaveData(filePathJSON, data, _documentDirectory);
        }
    }

    public ResData Load<ResData>(AbsSaveData data, string filePathJSON)
    {
        if(data.GetType() == typeof(StoryCollection) && File.Exists(Path.Combine(_storyPath, filePathJSON)))
        {
            string json = File.ReadAllText(Path.Combine(_storyPath, filePathJSON));
            return JsonUtility.FromJson<ResData>(json);
        }
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

    private void SaveData(string fileName, AbsSaveData data, string path)
    {
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Path.Combine(path, fileName), json);
    }
}
