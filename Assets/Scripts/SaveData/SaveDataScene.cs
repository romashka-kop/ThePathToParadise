using System.IO;
using UnityEngine;

[System.Serializable]
public class SaveDataScene : AbsSaveData
{
    public int IndexLvl = 0;

    public void Calculate()
    {
        IndexLvl *= 5163;
    }

    public int GetId()
    {
        return IndexLvl / 5163;
    }
}
