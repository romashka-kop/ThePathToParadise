using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UserInputKey : MonoBehaviour
{
    public TextMeshProUGUI[] textButtons;

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            foreach (KeyCode key in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(key))
                {
                    Debug.Log("Key pressed: " + key);
                    foreach (TextMeshProUGUI textPro in textButtons)
                    {
                        Debug.Log("hdfjhdkhf");
                        if (key.ToString() == textPro.text)
                        {
                            Debug.Log("Эта кнопка занята");
                        }
                        else
                        {
                            textPro.text = key.ToString();
                            textPro.GetComponentInParent<SettingsInputButton>().SetKeyCode(key);
                            gameObject.SetActive(false);
                        }
                    }
                }
            }
        }
    }
}
