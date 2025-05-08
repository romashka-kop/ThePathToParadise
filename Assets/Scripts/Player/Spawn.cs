using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject PrefabPlayer;

    private void Start()
    {
        //Instantiate(PrefabPlayer, gameObject.transform.position, Quaternion.identity);
        SpawnPlayer(PrefabPlayer, gameObject.transform);
        //Destroy(gameObject);
    }

    public static void SpawnPlayer(GameObject prefab, Transform transform)
    {
        Instantiate(prefab, transform.position, Quaternion.identity);
    }
}
