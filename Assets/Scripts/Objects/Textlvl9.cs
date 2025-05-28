using TMPro;
using UnityEngine;

public class Textlvl9 : MonoBehaviour
{
    private TextMeshProUGUI _text;
    private void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        _text.text = $"Чтобы включить магнит нажмите [{SettingsTransitions.DataSettings.PlayerControlKeyCode[9]}]";
    }
}
