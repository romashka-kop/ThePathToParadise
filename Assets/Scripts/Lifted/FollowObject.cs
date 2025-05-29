using UnityEngine;

public class FollowObject : MonoBehaviour
{
    [SerializeField] private GameObject _sourceCube;
    [SerializeField] private float _speed;
    [SerializeField] private Vector3 _distance;
    private Rigidbody _rb;

    private void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (LiftNDrop.IsLift || MagnetRigidbody.IsMagnet)
        {
            _rb.useGravity = false;
            Vector3 targetPosition = _sourceCube.transform.position + _distance;

            transform.rotation = _sourceCube.transform.rotation;

            transform.localScale = _sourceCube.transform.localScale;

            Vector3 newPosition = Vector3.MoveTowards(_rb.position, targetPosition, _speed * Time.fixedDeltaTime);
            _rb.MovePosition(newPosition);
        }
        else
        {
            _rb.useGravity=true;
        }
    }
}