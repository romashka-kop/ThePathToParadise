using UnityEngine;

public class Death : MonoBehaviour
{
    private GameObject _spawnPoint;
    private CharacterController _controller;

    private void Start()
    {
        _spawnPoint = GameObject.Find("SpawnPlayer");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Смерть");
            _controller = other.gameObject.GetComponent<CharacterController>();
            _controller.enabled = false;
            other.gameObject.transform.position = _spawnPoint.transform.position;
            _controller.enabled = true;
        }
    }
}
