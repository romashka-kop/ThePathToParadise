using UnityEngine;

public class MosaicDoor : MonoBehaviour
{
    public static int Score = 0;

    private void Start()
    {
        Score = 0;
    }

    void Update()
    {
        if (Score == 9)
        {
            gameObject.transform.localPosition = new Vector3(-23f, 9.2f, -117.73f);
        }
        else if (Score != 9)
        {
            {
                gameObject.transform.localPosition = new Vector3(-23f, -1.2f, -117.63f);
            }
        }
    }
}
