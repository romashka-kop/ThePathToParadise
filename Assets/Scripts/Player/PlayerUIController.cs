using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIController : MonoBehaviour
{
    private const string _tag = "Lifted";

    [SerializeField] private Texture _crosshairDefaultIcon;
    [SerializeField] private Texture _crosshairTakeIcon;

    [SerializeField] Transform _playerCamera;
    [SerializeField] private int _maxDistanceRay = 5;
    [SerializeField] private LayerMask _layerMask;

    private RawImage _imageCrosshair;

    private TextMeshProUGUI _textTake;
    private TextMeshProUGUI _textDrop;
    private TextMeshProUGUI _textDropForce;

    void Start()
    {
        _imageCrosshair = GameObject.Find("RawImage").GetComponent<RawImage>();
        _textTake = GameObject.Find("TextTake").GetComponent<TextMeshProUGUI>();
        _textDrop = GameObject.Find("TextDrop").GetComponent<TextMeshProUGUI>();
        _textDropForce = GameObject.Find("TextDropForce").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        ChangeUICrosshair(_crosshairDefaultIcon, "");

        RaycastHit hit;

        if (Physics.Raycast(_playerCamera.position, _playerCamera.forward, out hit, _maxDistanceRay, _layerMask))
        {
            if (hit.transform.CompareTag(_tag))
            {
                ChangeUICrosshair(_crosshairTakeIcon, $"[{SettingsTransitions.DataSettings.PlayerControlKeyCode[7]}]");
            }
        }

        if (LiftNDrop._isLift)
            ChangeUIText($"Положить [{SettingsTransitions.DataSettings.PlayerControlKeyCode[8]}]",$"Бросить [{SettingsTransitions.DataSettings.PlayerControlKeyCode[9]}]");
        else
            ChangeUIText("","");
    }

    private void ChangeUICrosshair(Texture image, string text)
    {
        _imageCrosshair.texture = image;
        _textTake.text = text;
    }

    private void ChangeUIText(string textDrop, string textDropForce)
    {
        _textDrop.text = textDrop;
        _textDropForce.text = textDropForce;
    }
}
