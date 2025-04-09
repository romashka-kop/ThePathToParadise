using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public static bool IsGrounded;

    [SerializeField] private float _speedPlayer = 1000f;
    [SerializeField] private float _forceJump;

    private Rigidbody _gameObj;
    private SaveDataSettings _dataSettings;


    private void Awake()
    {
       _dataSettings = new("SettingsData.json");
        _gameObj = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        RotatePlayer();
        MovePlayerPosition();
        JumpPlayer();
    }

    private void RotatePlayer()
    {
        float mouseX = Input.GetAxis("Mouse X") * _dataSettings.Sensivity * Time.deltaTime;
        _gameObj.angularVelocity = new Vector3(0, mouseX, 0);
    }

    private void MovePlayerPosition()
    {
        #region Расшифровка массива кнопок
        //Forward = MenuManager.DataSettings.PlayerControlKeyCode[0]
        //Backward = MenuManager.DataSettings.PlayerControlKeyCode[1]
        //Left = MenuManager.DataSettings.PlayerControlKeyCode[2]
        //Right = MenuManager.DataSettings.PlayerControlKeyCode[3]
        //Jump = MenuManager.DataSettings.PlayerControlKeyCode[4]
        //Squat = MenuManager.DataSettings.PlayerControlKeyCode[5]
        #endregion

        Vector3 movement = Vector3.zero;

        if (Input.GetKey(_dataSettings.PlayerControlKeyCode[0]))
            movement += transform.forward;

        if (Input.GetKey(_dataSettings.PlayerControlKeyCode[1]))
            movement -= transform.forward;

        if (Input.GetKey(_dataSettings.PlayerControlKeyCode[2]))
            movement -= transform.right;

        if (Input.GetKey(_dataSettings.PlayerControlKeyCode[3]))
            movement += transform.right;

        movement *= _speedPlayer * Time.deltaTime;

        _gameObj.velocity = movement;
    }

    private void JumpPlayer()
    {
        if (IsGrounded && Input.GetKey(_dataSettings.PlayerControlKeyCode[4]))
            _gameObj.velocity = new Vector3(_gameObj.velocity.x, _gameObj.velocity.y+1 * _forceJump);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Terrain")
            IsGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Terrain")
            IsGrounded = false;
    }
}
