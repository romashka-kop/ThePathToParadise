using System.Threading;
using UnityEngine;

public class ClearCubeBoxTrigger : MonoBehaviour
{
    private int _count = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (_count == 0)
            {
                InputCubeTrigger.ThisCount = 0;
                _count = 1;
            }
        }
    }
}
