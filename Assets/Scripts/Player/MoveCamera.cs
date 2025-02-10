using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    private GameObject _player;

    private void Awake()
    {
        _player = GameObject.Find("PlayerModel");
    }

    void Update()
    {
        gameObject.transform.position = _player.transform.position - new Vector3(0,10, 15);
    }
}
