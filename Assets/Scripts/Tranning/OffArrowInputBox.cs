using UnityEngine;

public class OffArrowInputBox : MonoBehaviour
{
    [SerializeField] GameObject _arrow;
 

    void Update()
    {
        if (InputCubeTrigger.IsOpen) _arrow.SetActive(false);
        else _arrow.SetActive(true);
    }
}
