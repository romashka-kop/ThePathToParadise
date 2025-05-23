using UnityEngine;

public class ForceJumpTrigger : MonoBehaviour
{
    [SerializeField] private float _speedLift = 50;
    [SerializeField] private float _speedPlayer = 25;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Lifted")
        {
            other.GetComponent<Rigidbody>().AddForce(Vector3.up * _speedLift,ForceMode.Impulse);
        }
        if (other.gameObject.tag == "Player")
        {
            MovePlayer.Velocity.y = _speedPlayer;
        }
    }
}
