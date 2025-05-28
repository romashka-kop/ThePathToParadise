using UnityEngine;

public class InputCubeTrigger : MonoBehaviour
{
    [SerializeField] GameObject _door;
    [SerializeField] bool _isMultiplay;
    [SerializeField] int _countMultiplay;

    public static int ThisCount;
    private Animator _animator;
    public static bool IsOpen = false;

    private void Start()
    {
        ThisCount = 0;
        _animator = _door.GetComponent<Animator>();
    }

    private void Update()
    {
        if (_isMultiplay)
        {
            if (ThisCount == _countMultiplay)
                SetDoor(true);
            else
                SetDoor(false);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name.Contains("openCube"))
        {
            if (_isMultiplay)
                ThisCount++;
            else
                SetDoor(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Contains("openCube"))
        {
            if (_isMultiplay)
                ThisCount--;
            else
                SetDoor(false);
        }
    }

    private void SetDoor(bool isOpen)
    {
        _animator.SetBool("Open", isOpen);
        IsOpen = isOpen;
    }
}
