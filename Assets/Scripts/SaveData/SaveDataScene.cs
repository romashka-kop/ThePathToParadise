using System.IO;
using UnityEngine;

[System.Serializable]
public class SaveDataScene : AbsSaveData
{
    public int IndexLvl = 0;

    public SaveDataScene(string path)
    {
        Load<SaveDataScene>(this, path);
    }
}
