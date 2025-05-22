using UnityEngine;

public class SwingLimit : MonoBehaviour
{
    void Update()
    {
        if (gameObject.transform.localRotation.x > 21.5f)
        {
            Vector3 angles = gameObject.transform.localEulerAngles;
            angles.x = 21.5f;
            gameObject.transform.localEulerAngles = angles;
        }
        else if (gameObject.transform.localEulerAngles.x > 300)
        {
            Vector3 angles = gameObject.transform.localEulerAngles;
            angles.x = 0f;
            gameObject.transform.localEulerAngles = angles;
        }
    }
}
