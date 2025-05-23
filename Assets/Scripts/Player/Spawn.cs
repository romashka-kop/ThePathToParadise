using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject PrefabPlayer;

    private void Start()
    {
        SpawnPlayer(PrefabPlayer, gameObject.transform);
    }

    public static void SpawnPlayer(GameObject prefab, Transform transform)
    {
        Instantiate(prefab, transform.position, Quaternion.identity);
    }
}
