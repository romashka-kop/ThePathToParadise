using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;

public class SwitchDropdownValue : MonoBehaviour
{
    public TMP_Dropdown Dropdown;

    public void SwitchValue()
    {
        switch (gameObject.name)
        {
            case "ArrowLeft":
                Dropdown.value -= 1;
                break;
            case "ArrowRight":
                Dropdown.value += 1;
                break;
        }
    }
}
