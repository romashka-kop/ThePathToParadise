using UnityEngine;

public class Mosaic : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(gameObject.tag == other.gameObject.name)
        {
            MosaicDoor.Score += 1;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (gameObject.tag == other.gameObject.name)
        {
            MosaicDoor.Score -= 1;
        }
    }
}
