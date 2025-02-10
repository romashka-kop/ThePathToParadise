using UnityEngine;

public class ControlGravity : MonoBehaviour
{
    [SerializeField] private float _forceGravity;
    private Rigidbody _rb;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _rb.AddForce(Vector3.down * _forceGravity, ForceMode.Impulse);
    }
}
