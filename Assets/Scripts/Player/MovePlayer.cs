using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] private float _speedWalk = 5f;
    [SerializeField] private float _speedSprint = 10f;
    [SerializeField] private float _speedSquat = 3f;
    [SerializeField] private float _gravity;
    [SerializeField] private float _jumpForce;

    private float _finalSpeed;
    private CharacterController _characterController;
    private Vector3 _velocity;

    private enum PlayerState { Squat, Sprint, Walk}
    private PlayerState _playerState;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
        Sprint();
        Squat();
        MovePlayerPosition();
        Gravity(_characterController.isGrounded);
        Jump(_characterController.isGrounded);
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
        //Take = MenuManager.DataSettings.PlayerControlKeyCode[7]
        //Drop = MenuManager.DataSettings.PlayerControlKeyCode[8]
        //ForceDrop = MenuManager.DataSettings.PlayerControlKeyCode[9]
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

        _characterController.Move(movement * _finalSpeed * Time.deltaTime);
    }

    private void Gravity(bool isGrounded)
    {
        if (isGrounded && _velocity.y < 0)
            _velocity.y = -1f;

        _velocity.y -= _gravity * Time.fixedDeltaTime;
        _characterController.Move(_velocity * Time.fixedDeltaTime);
    }

    private void Jump(bool isGrounded)
    {
        if (isGrounded && Input.GetKey(SettingsTransitions.DataSettings.PlayerControlKeyCode[4]))
            _velocity.y = _jumpForce;
    }

    private void Squat()
    {
        if (Input.GetKey(SettingsTransitions.DataSettings.PlayerControlKeyCode[6]))
        {
            _characterController.height =  0.5f;
            _playerState =  PlayerState.Squat;
        }
        else _characterController.height = 2f;
    }

    private void Sprint()
    {
        if(Input.GetKey(SettingsTransitions.DataSettings.PlayerControlKeyCode[5]))
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
}
