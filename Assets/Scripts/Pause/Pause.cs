using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject PausePanel;

    private Animator _animatorPause;

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            PausePanel.SetActive(true);
            _animatorPause = PausePanel.GetComponent<Animator>();
            _animatorPause.SetTrigger("OpenPause");
            PauseTransitions.ChangePauseMode(CursorLockMode.None, true, 0);
        }
    }
}
