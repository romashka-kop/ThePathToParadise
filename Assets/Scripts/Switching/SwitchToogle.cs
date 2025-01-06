using UnityEngine;
using UnityEngine.UI;

public class SwitchToogle : MonoBehaviour
{
    public void Update()
    {
        ColorBlock thicColor = gameObject.GetComponent<Toggle>().colors;

        if (gameObject.GetComponent<Toggle>().isOn)
        {
            thicColor.normalColor = new Color(0.7843138f, 0.7843138f, 0.7843138f);
            gameObject.GetComponent<Toggle>().colors = thicColor;
        }
        else
        {
            thicColor.normalColor = new Color(0.3058824f, 0.3058824f, 0.3058824f);
            gameObject.GetComponent<Toggle>().colors = thicColor;
        }
    }
}
