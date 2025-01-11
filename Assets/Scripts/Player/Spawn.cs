using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject PrefabPlayer;

    private void Start()
    {
        gameObject.transform.position = MenuManager.DataPlayer.PlayerPosition;
        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        Instantiate(PrefabPlayer,gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
