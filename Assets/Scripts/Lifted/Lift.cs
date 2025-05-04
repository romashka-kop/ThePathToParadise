using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Lift : MonoBehaviour
{
    private const string _tag = "Lifted";
    private const int _defaultLayer = 0;
    private const int _liftLayer = 3;

    private Rigidbody _rb;

    private void Start()
    {
        this.gameObject.tag = _tag;
        _rb = GetComponent<Rigidbody>();
    }

    public void PrepareForLift()
    {
        this.gameObject.layer = _liftLayer;
        _rb.useGravity = false;
        _rb.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
    }

    public void PrepareForDrop()
    {
        this.gameObject.layer = _defaultLayer;
        _rb.useGravity = true;
        _rb.collisionDetectionMode = CollisionDetectionMode.Discrete;
    }

    public void PrepareForDropWithForce(float dropForce, Vector3 dropDirection)
    {
        this.gameObject.layer = _defaultLayer;
        _rb.useGravity = true;
        _rb.collisionDetectionMode = CollisionDetectionMode.Discrete;

        _rb.AddForce(dropDirection * dropForce, ForceMode.Impulse);
    }
}
