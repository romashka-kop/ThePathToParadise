using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] private float _speedWalk = 5f;
    [SerializeField] private float _speedSprint = 10f;
    [SerializeField] private float _speedSquat = 3f;
    [SerializeField] private float _gravity;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _pointTransformSpeed;
    [SerializeField] private Transform _point;
    [SerializeField] private PlayerSoundControll _soundControll;  // ссылка на скрипт с звуком
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _distaneRay = 4f;

    private float _finalSpeed;
    private float _smoothTime;

    private float _limitPointMax = 4f;
    private float _limitPointMin = 1.17f;

    private CharacterController _characterController;
    public static Vector3 Velocity;

    private enum PlayerState { Squat, Sprint, Walk }
    private PlayerState _playerState;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
        Jump(_characterController.isGrounded);
        Sprint();
        Squat();
        MovePlayerPosition();
        Gravity(_characterController.isGrounded);
        MovePointLift();
    }

    private void MovePlayerPosition()
    {
        #region Клавиши управления
        //Forward = MenuManager.DataSettings.PlayerControlKeyCode[0]
        //Backward = MenuManager.DataSettings.PlayerControlKeyCode[1]
        //Left = MenuManager.DataSettings.PlayerControlKeyCode[2]
        //Right = MenuManager.DataSettings.PlayerControlKeyCode[3]
        //Jump = MenuManager.DataSettings.PlayerControlKeyCode[4]
        //Run = MenuManager.DataSettings.PlayerControlKeyCode[5]
        //Squat = MenuManager.DataSettings.PlayerControlKeyCode[6]
        //Take/Drop = MenuManager.DataSettings.PlayerControlKeyCode[7]
        //ForceDrop = MenuManager.DataSettings.PlayerControlKeyCode[8]
        #endregion

        Vector3 movement = Vector3.zero;

        if (Input.GetKey(SettingsTransitions.DataSettings.PlayerControlKeyCode[0]))
            movement += transform.forward;

        if (Input.GetKey(SettingsTransitions.DataSettings.PlayerControlKeyCode[1]))
            movement -= transform.forward;

        if (Input.GetKey(SettingsTransitions.DataSettings.PlayerControlKeyCode[2]))
            movement -= transform.right;

        if (Input.GetKey(SettingsTransitions.DataSettings.PlayerControlKeyCode[3]))
            movement += transform.right;

        SetSpeedPlayer();

        Vector3 vector = movement * _finalSpeed * Time.deltaTime;

        _characterController.Move(vector);

        if (vector.magnitude > 0 && CheckGrounded())
        {
            _soundControll.PlayFootSteps();
        }
        else
        {
            _soundControll.StopFootSteps();
        }
    }

    private void Gravity(bool isGrounded)
    {
        if (isGrounded && Velocity.y < 0)
            Velocity.y = -1f;

        Velocity.y -= _gravity * Time.fixedDeltaTime;
        _characterController.Move(Velocity * Time.fixedDeltaTime);
    }

    private void Jump(bool isGrounded)
    {
        if (isGrounded && Input.GetKey(SettingsTransitions.DataSettings.PlayerControlKeyCode[4]))
        {
            Velocity.y = _jumpForce;
        }
    }

    private void Squat()
    {
        if (Input.GetKey(SettingsTransitions.DataSettings.PlayerControlKeyCode[6]))
        {
            _characterController.height = 0.5f;
            _playerState = PlayerState.Squat;
        }
        else _characterController.height = 2f;
    }

    private void Sprint()
    {
        if (Input.GetKey(SettingsTransitions.DataSettings.PlayerControlKeyCode[5]))
            _playerState = PlayerState.Sprint;
    }

    private void SetSpeedPlayer()
    {
        _finalSpeed = _playerState switch
        {
            PlayerState.Squat => _speedSquat,
            PlayerState.Sprint => _speedSprint,
            _ => _speedWalk
        };
        _playerState = PlayerState.Walk;
    }

    private void MovePointLift()
    {
        float targetZ = _point.localPosition.z;
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        float velocityZ = 0;

        CalculationNewPositionPoint(scroll, targetZ, ref velocityZ);
    }

    private void CalculationNewPositionPoint(float scroll, float targetZ, ref float velocityZ)
    {
        targetZ += scroll * _pointTransformSpeed;

        if (targetZ > _limitPointMax)
            targetZ = _limitPointMax;
        else if (targetZ < _limitPointMin)
            targetZ = _limitPointMin;

        float newZ = Mathf.SmoothDamp(_point.localPosition.z, targetZ, ref velocityZ, _smoothTime);
        _point.localPosition = new Vector3(0, 0, newZ);
    }

    private bool CheckGrounded()
    {
        RaycastHit hit;
        
        if (Physics.Raycast(transform.position, Vector3.down, out hit, _distaneRay, _groundLayer))
        {
            return true; // Луч попал на землю
        }
        else
        {
            return false; // Земля не найдена в пределах луча
        }
    }
}