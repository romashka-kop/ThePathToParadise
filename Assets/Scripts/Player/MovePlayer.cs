using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] private float _speedPlayer = 5f;
    [SerializeField] private float _forceJump;

    private SaveDataSettings _dataSettings = new();
    private CharacterController _characterController;

    private void Start()
    {
        _dataSettings = _dataSettings.Load<SaveDataSettings>(_dataSettings, "SettingsData.json");
        _characterController = GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
        MovePlayerPosition();
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
}
