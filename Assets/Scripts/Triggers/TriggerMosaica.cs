using UnityEngine;

public class TriggerMosaica : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
            MosaicDoor.Score = 0;
    }
}
