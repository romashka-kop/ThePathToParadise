using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject PausePanel;

    private Animator _animatorPause;
    public static bool IsPause = false;
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            IsPause = true;
            PausePanel.SetActive(true);
            _animatorPause = PausePanel.GetComponent<Animator>();
            _animatorPause.SetTrigger("OpenPause");
            PauseTransitions.ChangePauseMode(CursorLockMode.None, true, 0);
        }
    }
}
