using UnityEngine;

public class BlockParcurTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Lifted" && other.gameObject.layer == 7)
        {
            other.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.back * 200, ForceMode.Impulse);
        }
    }
}
