using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float Speed = 0.5f;
    public GameObject SettingsCanvas;

    private Rigidbody rb;
    private Vector3 _moveVector;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        MovePlayerPosition();
        RotatePlayer();
        OpenPauseMenu();
    }

    private void MovePlayerPosition()
    {
        _moveVector.x = Input.GetAxis("Horizontal");
        _moveVector.z = Input.GetAxis("Vertical");
        rb.MovePosition(rb.position + _moveVector * Speed * Time.deltaTime);


        //if (Input.GetKeyDown())
        //{

        //}
    }

    private void RotatePlayer()
    {
        
    }

    private void OpenPauseMenu()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SettingsCanvas.SetActive(true);
        }
    }
}
