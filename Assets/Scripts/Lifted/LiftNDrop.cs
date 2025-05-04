using UnityEngine;
using UnityEngine.UI;

public class LiftNDrop : MonoBehaviour
{
    private const string _tag = "Lifted";

    private bool _isLift = false;

    [SerializeField] private RawImage _imageCrosshair;

    [SerializeField] private Texture _crosshairDefaultIcon;
    [SerializeField] private Texture _crosshairTakeIcon;

    [SerializeField] private float _dropForce = 10;
    [SerializeField] private float _speedLift = 15;

    [SerializeField] private int _maxDistanceRay = 3;

    [SerializeField] private Transform _point;
    [SerializeField] private Transform _playerCamera;

    [SerializeField] private LayerMask _layerMask;

    private Rigidbody _rigidbodyLiftedObject;

    private GameObject _liftedObject;

    void Update()
    {
        _imageCrosshair.texture = _crosshairDefaultIcon;
        RaycastHit hit;

        if (Physics.Raycast(_playerCamera.position, _playerCamera.forward, out hit, _maxDistanceRay, _layerMask))
        {
            if (hit.transform.CompareTag(_tag))
            {
                _imageCrosshair.texture = _crosshairTakeIcon;

                if (Input.GetKey(MovePlayer.DataSettings.PlayerControlKeyCode[5]))
                    PrepareForLift(hit);
            }
        }

        if (_liftedObject != null)
        {
            if (Input.GetKeyDown(MovePlayer.DataSettings.PlayerControlKeyCode[6]))
            {
                _isLift = false;
                Drop();
            }
            if (Input.GetKeyDown(MovePlayer.DataSettings.PlayerControlKeyCode[7]))
            {
                DropWithForce();
            }
        }
    }

    void FixedUpdate()
    {
        if (_isLift && _liftedObject != null)
            Lift();
    }

    private void Lift()
    {
        Vector3 liftDirection = _point.position - _liftedObject.transform.position;
        _rigidbodyLiftedObject.linearVelocity = liftDirection * _speedLift;
    }

    private void DropWithForce()
    {
        _liftedObject.GetComponent<Lift>().PrepareForDropWithForce(_dropForce, _playerCamera.forward);
        PrepareForDrop();
    }

    private void Drop()
    {
        _liftedObject.GetComponent<Lift>().PrepareForDrop();
        PrepareForDrop();
    }

    private void PrepareForLift(RaycastHit hit)
    {
        _imageCrosshair.texture = _crosshairDefaultIcon;
        _isLift = true;
        _liftedObject = hit.transform.gameObject;
        _rigidbodyLiftedObject = _liftedObject.GetComponent<Rigidbody>();
        _liftedObject.GetComponent<Lift>().PrepareForLift();
    }

    private void PrepareForDrop()
    {
        _isLift = false;
        _liftedObject = null;
        _rigidbodyLiftedObject = null;
    }
}
