using UnityEngine;

public class Death : MonoBehaviour
{
    [SerializeField] private GameObject _spawnPoint;
    [SerializeField] private GameObject _spawnCube;
    private CharacterController _controller;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _controller = other.gameObject.GetComponent<CharacterController>();
            _controller.enabled = false;
            other.gameObject.transform.position = _spawnPoint.transform.position;
            _controller.enabled = true;
        }
        else if (other.gameObject.name == "openCube")
        {
            other.gameObject.transform.position = _spawnCube.transform.position;
            Vector3 direction = other.GetComponent<Rigidbody>().linearVelocity.normalized;
            other.GetComponent<Rigidbody>().linearVelocity = direction * 0;
        }
    }
}
