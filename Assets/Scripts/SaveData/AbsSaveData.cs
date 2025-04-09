using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

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
            //Debug.Log(Application.persistentDataPath + "" + path);
            string json = File.ReadAllText(Application.persistentDataPath + "" + path);
            return JsonUtility.FromJson<ResData>(json);
            //return null;
        }
        else
        {
            data.GetType();
            Save(data, path);
            return Load<ResData>(data, path);
        }
    }
}
