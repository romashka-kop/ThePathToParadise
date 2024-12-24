using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SettingsInputButton : MonoBehaviour
{
    public GameObject panelInput;
    public KeyCode KeyCode { get; private set; }

    private void Start()
    {
        TextMeshProUGUI textMesh = gameObject.GetComponentInChildren<TextMeshProUGUI>();
    }

    public void SetKeyCode(KeyCode keyCode)
    {
        KeyCode = keyCode;
    }

    public KeyCode GetKeyCode()
    {
        return KeyCode;
    }

    public void ClickToInputUserKey()
    {
        panelInput.SetActive(true);
        Debug.Log(GetKeyCode());
    }
}
