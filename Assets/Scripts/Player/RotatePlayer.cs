using UnityEngine;

public class RotatePlayer : MonoBehaviour
{
    [SerializeField] private Transform _character;
    private float _xRotation;
    private readonly SaveDataSettings _saveDataSettings = new();

    void Start()
    {
        PauseTransitions.ChangePauseMode(CursorLockMode.Locked, false, 1);
    }

    void FixedUpdate()
    {
        RotatePerson();
    }

    private void RotatePerson()
    {
        float mouseX = Input.GetAxis("Mouse X") * _saveDataSettings.Sensivity * Time.fixedDeltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * _saveDataSettings.Sensivity * Time.fixedDeltaTime;
        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90, 90);
        transform.localRotation = Quaternion.Euler(_xRotation, 0, 0);
        _character.Rotate(Vector3.up * mouseX);
    }
}
