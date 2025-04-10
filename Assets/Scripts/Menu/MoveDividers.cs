using UnityEngine;
using UnityEngine.UIElements;

public class MoveDividers : MonoBehaviour
{
    private float _speed = -30f;
    public GameObject Game;

    void Update()
    {
        transform.Translate(_speed * Time.deltaTime, 0, 0);
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if(collision.gameObject.tag == "Spawn" || collision.gameObject.tag == "Destroy")
    //    {
    //        _speed *= -1;
    //        Debug.Log(_speed);
    //    }
    //}

    //private void OnTriggerStay(Collider other)
    //{
        
    //}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Spawn" || collision.gameObject.tag == "Destroy")
        {
            _speed *= -1;
            Debug.Log(_speed);
        }
    }
}
