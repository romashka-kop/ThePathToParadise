using TMPro;
using UnityEngine;

public class Tranning : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _text;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && gameObject.name == "Squat")
            _text.text = $"������� [{SettingsTransitions.DataSettings.PlayerControlKeyCode[6]}], ����� ��������";
        else if (other.gameObject.tag == "Player" && gameObject.name == "Jump")
            _text.text = $"������� [{SettingsTransitions.DataSettings.PlayerControlKeyCode[4]}], ����� ��������";
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _text.text = "";
        }
    }
}
