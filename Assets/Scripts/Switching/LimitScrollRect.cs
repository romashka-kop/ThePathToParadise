using UnityEngine;

public class LimitScrollRect : MonoBehaviour
{
    public float LimitScrollPositionTopY;
    public float LimitScrollPositionBottomY;

    public void ChangePosition()
    {
        Vector3 position = gameObject.transform.localPosition;

        if (position.y > LimitScrollPositionTopY)
        {
            gameObject.transform.localPosition = new Vector3(position.x, LimitScrollPositionTopY, position.z);
        }
        else if (position.y < LimitScrollPositionBottomY)
        {
            gameObject.transform.localPosition = new Vector3(position.x, LimitScrollPositionBottomY, position.z);
        }
    }
}
