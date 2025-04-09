using UnityEngine;
using System.IO;

[System.Serializable]
public class SaveDataPlayer : AbsSaveData
{
    public Vector3 PlayerPosition = new Vector3(0,5,0);
    public Vector3 PlayerRotation = new Vector3(0,0,0);

    public SaveDataPlayer(string path)
    {
        Load<SaveDataPlayer>(this, path);
    }
}
