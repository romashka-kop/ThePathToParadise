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
    private TextMeshProUGUI _textOffMagnet;
    private TextMeshProUGUI _textDropMagnet;
    private TextMeshProUGUI _textDropForce;

    void Start()
    {
        _imageCrosshair = GameObject.Find("RawImage").GetComponent<RawImage>();
        _textTake = GameObject.Find("TextTake").GetComponent<TextMeshProUGUI>();
        _textDrop = GameObject.Find("TextDrop").GetComponent<TextMeshProUGUI>();
        _textOffMagnet = GameObject.Find("TextOffMagnet").GetComponent<TextMeshProUGUI>();
        _textDropMagnet = GameObject.Find("TextDropMagnet").GetComponent<TextMeshProUGUI>();
        _textDropForce = GameObject.Find("TextDropForce").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        ChangeUICrosshair(_crosshairDefaultIcon, "");

        RaycastHit hit;

        if (Physics.Raycast(_playerCamera.position, _playerCamera.forward, out hit, _maxDistanceRay, _layerMask))
        {
            if (hit.transform.CompareTag(_tag) && LiftNDrop.IsLift == false)
                ChangeUICrosshair(_crosshairTakeIcon, $"[{SettingsTransitions.DataSettings.PlayerControlKeyCode[7]}]");
        }

        if (LiftNDrop.IsLift)
            ChangeUIText($"�������� [{SettingsTransitions.DataSettings.PlayerControlKeyCode[7]}]", $"������� [{SettingsTransitions.DataSettings.PlayerControlKeyCode[8]}]");
        else
            ChangeUIText("", "");

        if (MagnetRigidbody.IsMagnet)
        {
            _textOffMagnet.text = $"��������� ������ [{SettingsTransitions.DataSettings.PlayerControlKeyCode[9]}]";
            _textDropMagnet.text = $"����� ������� [{SettingsTransitions.DataSettings.PlayerControlKeyCode[10]}]";
        }
        else
        {
            _textOffMagnet.text = "";
            _textDropMagnet.text = "";
        }
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
