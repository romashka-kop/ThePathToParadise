using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class OffArrow : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _textForCube;

    private void Update()
    {
        if(LiftNDrop.IsLift == true && LiftNDrop.LiftedObject.name == "openCube")
        {
            gameObject.SetActive(false);
            ShowText();
        }
    }

    private async void ShowText()
    {
        _textForCube.text = "���� ������ ����� ���������� � ������������, ����� ������� �����";
        await Task.Delay(7000);
        _textForCube.text = "";
        await Task.Delay(1500);
        _textForCube.text = "�� ������ ���� ����� ���������� � �������� �������";
        await Task.Delay(7000);
        _textForCube.text = "";
    }
}
