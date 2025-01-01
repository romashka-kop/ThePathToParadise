using UnityEngine;
using UnityEngine.UI;

public class SwitchToogle : MonoBehaviour
{
    public Toggle ToggleNo;
    public Toggle ToggleYes;

    public void Update()
    {
        ColorBlock cbNo = ToggleNo.colors;
        ColorBlock cbYes = ToggleYes.colors;

        //if (ToggleYes.isOn)
        //{
        ////    cb.normalColor = new Color(0.7843138f, 0.7843138f, 0.7843138f);
        ////    gameObject.GetComponent<Toggle>().colors = cb;
        ////}
        //else
        //{
        //    //cb.normalColor = new Color(0.3058824f, 0.3058824f, 0.3058824f);
        //    //gameObject.GetComponent<Toggle>().colors = cb;
        //}






    }
}
