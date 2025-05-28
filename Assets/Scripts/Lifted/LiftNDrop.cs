using UnityEngine;

public class LiftNDrop : MonoBehaviour
{
    private const string _tag = "Lifted";

    public static bool IsLift = false;

    [SerializeField] private float _dropForce = 10;
    [SerializeField] private float _speedLift = 15;

    [SerializeField] private int _maxDistanceRay = 5;

    [SerializeField] private Transform _point;
    [SerializeField] private Transform _playerCamera;

    [SerializeField] private LayerMask _layerMaskForLift;
    [SerializeField] private LayerMask _layerMaskForDrop;

    [SerializeField] private AudioClip _clip;

    [SerializeField] private CharacterController _charactar;

    private Rigidbody _rigidbodyLiftedObject;

    private float _maxDistanceObject = 15f;
    private float _maxDistancePoint = 9f;
    private float _rotationSpeed = 4f;

    public static GameObject LiftedObject;

    private AudioSource _audio;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        RaycastHit hit;
        RaycastHit hitCanLift;

        if (Physics.Raycast(_playerCamera.position, _playerCamera.forward, out hit, _maxDistanceRay, _layerMaskForLift))
        {
            if (MagnetRigidbody.IsMagnet == false)
            {
                if (hit.transform.CompareTag(_tag))
                {
                    if (IsLift == false && Input.GetKeyDown(SettingsTransitions.DataSettings.PlayerControlKeyCode[7]))
                    {
                        _audio.resource = _clip;
                        _audio.Play();
                        PrepareForLift(hit);
                    }
                }
            }
        }
        else if (LiftedObject != null && IsLift && Pause.IsPause == false)
        {
            float distanceObjectPlayer = Vector3.Distance(gameObject.transform.position, LiftedObject.transform.position);
            float distanceObjectPoint = Vector3.Distance(_point.position, LiftedObject.transform.position);

            if (distanceObjectPlayer > _maxDistanceObject)
                Drop();
            else if (Input.GetKeyDown(SettingsTransitions.DataSettings.PlayerControlKeyCode[7]))
                Drop();
            else if (Input.GetKeyDown(SettingsTransitions.DataSettings.PlayerControlKeyCode[8]))
                DropWithForce();
            else if (Physics.Raycast(_playerCamera.position, Vector3.down, out hit, 10, _layerMaskForDrop))
            {
                if (hit.transform.CompareTag(_tag) && distanceObjectPoint > _maxDistancePoint)
                    Drop();
            }
        }
    }

    void FixedUpdate()
    {
        if (IsLift && LiftedObject != null)
            Lift();
    }

    private void Lift()
    {
        Vector3 liftDirection = _point.position - LiftedObject.transform.position;
        _rigidbodyLiftedObject.linearVelocity = liftDirection * _speedLift;

        _rigidbodyLiftedObject.transform.rotation = Quaternion.Slerp(_rigidbodyLiftedObject.transform.rotation, _playerCamera.rotation, _rotationSpeed * Time.deltaTime);
    }

    private void DropWithForce()
    {
        LiftedObject.GetComponent<Lift>().PrepareForDropWithForce(_dropForce, _playerCamera.forward);
        PrepareForDrop();
    }

    private void Drop()
    {
        LiftedObject.GetComponent<Lift>().PrepareForDrop();
        PrepareForDrop();
    }

    private void PrepareForLift(RaycastHit hit)
    {
        IsLift = true;
        LiftedObject = hit.transform.gameObject;
        _rigidbodyLiftedObject = LiftedObject.GetComponent<Rigidbody>();
        LiftedObject.GetComponent<Lift>().PrepareForLift();
    }

    private void PrepareForDrop()
    {
        IsLift = false;
        LiftedObject = null;
        _rigidbodyLiftedObject = null;
    }
}
