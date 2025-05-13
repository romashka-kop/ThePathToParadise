using UnityEngine;
using UnityEngine.UI;

public class LiftNDrop : MonoBehaviour
{
    private const string _tag = "Lifted";

    public static bool IsLift = false;

    [SerializeField] private float _dropForce = 10;
    [SerializeField] private float _speedLift = 15;

    [SerializeField] private int _maxDistanceRay = 5;

    [SerializeField] private Transform _point;
    [SerializeField] private Transform _playerCamera;

    [SerializeField] private LayerMask _layerMask;

    private Rigidbody _rigidbodyLiftedObject;

    private float _maxDistanceObject = 12f;

    private GameObject _liftedObject;

    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(_playerCamera.position, _playerCamera.forward, out hit, _maxDistanceRay, _layerMask))
        {
            if (hit.transform.CompareTag(_tag))
            {
                if (IsLift == false && Input.GetKeyDown(SettingsTransitions.DataSettings.PlayerControlKeyCode[7]))
                    PrepareForLift(hit);
            }
        }
        else if (_liftedObject != null && IsLift)
        {
            float distanceObject = Vector3.Distance(gameObject.transform.position, _liftedObject.transform.position);

            if (distanceObject > _maxDistanceObject)
                Drop();
            else if (Input.GetKeyDown(SettingsTransitions.DataSettings.PlayerControlKeyCode[7]))
                Drop();
            else if (Input.GetKeyDown(SettingsTransitions.DataSettings.PlayerControlKeyCode[8]))
                DropWithForce();
        }
    }

    void FixedUpdate()
    {
        if (IsLift && _liftedObject != null)
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
        IsLift = true;
        _liftedObject = hit.transform.gameObject;
        _rigidbodyLiftedObject = _liftedObject.GetComponent<Rigidbody>();
        _liftedObject.GetComponent<Lift>().PrepareForLift();
    }

    private void PrepareForDrop()
    {
        IsLift = false;
        _liftedObject = null;
        _rigidbodyLiftedObject = null;
    }
}
