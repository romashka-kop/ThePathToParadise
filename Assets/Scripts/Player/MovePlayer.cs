using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] private float _speedPlayer = 5f;
    [SerializeField] private float _forceJump;
    [SerializeField] private float _gravity;
    [SerializeField] private float _jumpForce;

    private SaveDataSettings _dataSettings = new();
    private CharacterController _characterController;
    private Vector3 _velocity;

    private void Start()
    {
        _dataSettings = _dataSettings.Load<SaveDataSettings>(_dataSettings, "SettingsData.json");
        _characterController = GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
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
        //Squat = MenuManager.DataSettings.PlayerControlKeyCode[5]
        #endregion

        Vector3 movement = Vector3.zero;

        if (Input.GetKey(_dataSettings.PlayerControlKeyCode[0]))
        {
            movement += transform.forward;
        }

        if (Input.GetKey(_dataSettings.PlayerControlKeyCode[1]))
        {
            movement -= transform.forward;
        }

        if (Input.GetKey(_dataSettings.PlayerControlKeyCode[2]))
        {
            movement -= transform.right;
        }

        if (Input.GetKey(_dataSettings.PlayerControlKeyCode[3]))
        {
            movement += transform.right;
        }

        _characterController.Move(movement * _speedPlayer * Time.deltaTime);
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
        if (isGrounded && Input.GetKey(_dataSettings.PlayerControlKeyCode[4]))
        {
            _velocity.y *= _jumpForce;
        }
    }
}
