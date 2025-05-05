using Unity.VisualScripting;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject PrefabPlayer;

    private void Start()
    {
        Instantiate(PrefabPlayer, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
