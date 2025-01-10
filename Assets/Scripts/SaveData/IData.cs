using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IData
{
    void Save(IData data, string path);

    IData Load(IData data, string path);
}
