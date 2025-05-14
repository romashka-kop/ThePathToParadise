using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Lift : MonoBehaviour
{
    [SerializeField] private float _mass = 1;
    private const string _tag = "Lifted";
    private const byte _defaultLayer = 7;
    private const byte _liftLayer = 3;

    private Rigidbody _rb;

    private void Start()
    {
        this.gameObject.tag = _tag;
        _rb = GetComponent<Rigidbody>();
        _rb.mass = _mass;
    }

    public void PrepareForLift()
    {
        GeneralPrepare(_liftLayer, false, CollisionDetectionMode.ContinuousSpeculative, true);
    }

    public void PrepareForDrop()
    {
        GeneralPrepare(_defaultLayer, true, CollisionDetectionMode.Discrete, false);
    }

    public void PrepareForDropWithForce(float dropForce, Vector3 dropDirection)
    {
        GeneralPrepare(_defaultLayer, true, CollisionDetectionMode.Discrete, false);

        _rb.AddForce(dropDirection * dropForce, ForceMode.Impulse);
    }

    private void GeneralPrepare(byte layer, bool useGravity, CollisionDetectionMode mode, bool freezzeRotation)
    {
        this.gameObject.layer = layer;
        _rb.useGravity = useGravity;
        _rb.collisionDetectionMode = mode;
        _rb.freezeRotation = freezzeRotation;
    }
}
