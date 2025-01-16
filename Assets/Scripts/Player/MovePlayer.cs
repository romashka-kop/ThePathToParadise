using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float Speed = 0.5f;
    private float _verticalRotation = 0f;

    public GameObject SettingsCanvas;

    void FixedUpdate()
    {
        MovePlayerPosition();
        OpenPauseMenu();
    }

    private void MovePlayerPosition()
    {
        float mouseX = Input.GetAxis("Mouse X") * MenuManager.DataSettings.Sensivity;
        float mouseY = Input.GetAxis("Mouse Y") * MenuManager.DataSettings.Sensivity;

        _verticalRotation -= mouseY * Time.deltaTime;
        _verticalRotation = Mathf.Clamp(_verticalRotation, -80f, 80f);

        Camera.main.transform.localRotation = Quaternion.Euler(_verticalRotation, 0f, 0f);
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime));

        Vector3 movement = Vector3.zero;

        #region Расшифровка массива кнопок
        //Forward = MenuManager.DataSettings.PlayerControlKeyCode[0]
        //Backward = MenuManager.DataSettings.PlayerControlKeyCode[1]
        //Left = MenuManager.DataSettings.PlayerControlKeyCode[2]
        //Right = MenuManager.DataSettings.PlayerControlKeyCode[3]
        //Jump = MenuManager.DataSettings.PlayerControlKeyCode[4]
        //Squat = MenuManager.DataSettings.PlayerControlKeyCode[5]
        #endregion

        if (Input.GetKey(MenuManager.DataSettings.PlayerControlKeyCode[0])) 
            movement += transform.forward;
            
        if (Input.GetKey(MenuManager.DataSettings.PlayerControlKeyCode[1])) 
            movement -= transform.forward;
            
        if (Input.GetKey(MenuManager.DataSettings.PlayerControlKeyCode[2])) 
            movement -= transform.right;
            
        if (Input.GetKey(MenuManager.DataSettings.PlayerControlKeyCode[3])) 
            movement += transform.right;

        movement.Normalize();
        movement *= Speed * Time.deltaTime;

        transform.position += movement;
    }

    private void OpenPauseMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

        }
    }
}
