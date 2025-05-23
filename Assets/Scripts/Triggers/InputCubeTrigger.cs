using UnityEngine;

public class InputCubeTrigger : MonoBehaviour
{
    [SerializeField] GameObject _door;
    [SerializeField] GameObject _triggerCube;

    private Animator _animator;
    public static bool IsOpen = false;

    private void Start()
    {
        _animator = _door.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject == _triggerCube)
        {
            _animator.SetBool("Open", true);
            IsOpen = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == _triggerCube)
        {
            _animator.SetBool("Open", false);
            IsOpen = false;
        }
    }
}
