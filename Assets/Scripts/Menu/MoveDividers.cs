using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDividers : MonoBehaviour
{
    public GameObject game;

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Spawn")
        {
            Instantiate(gameObject);
        }
        else if(collision.gameObject.tag == "Destroy")
        {

        }
    }
}
