using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SwitchToogle : MonoBehaviour
{
    void Update()
    {
        ColorBlock cb = gameObject.GetComponent<Toggle>().colors;
        if (gameObject.GetComponent<Toggle>().isOn)
        {
            cb.normalColor = new Color(0.7843138f, 0.7843138f, 0.7843138f);
            gameObject.GetComponent<Toggle>().colors = cb;
        }
        else
        {
            cb.normalColor = new Color(0.3058824f, 0.3058824f, 0.3058824f);
            gameObject.GetComponent<Toggle>().colors = cb;
        }
    }
}
