using UnityEngine;

public class ColisionDroper : MonoBehaviour
{
    [SerializeField] private GameObject _spawnPoint;
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
    }
}
