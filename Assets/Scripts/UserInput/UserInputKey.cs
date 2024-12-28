using TMPro;
using UnityEngine;

public class UserInputKey : MonoBehaviour
{
    public static GameObject game;

    public TextMeshProUGUI[] textButtons;

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            foreach (KeyCode key in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(key))
                {
                    bool isNotCopy = false;
                    foreach (TextMeshProUGUI textPro in textButtons)
                    {
                        if (key.ToString() == textPro.text)
                        {
                            gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Такая кнопка уже задана, выбери другую.(Backspace - отмена)";
                            isNotCopy = false;
                            break;
                        }
                        else
                        {
                            isNotCopy = true;
                            gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Нажми на нужную кнопку.(Backspace - отмена)";
                        }
                    }
                    if(isNotCopy)
                    {
                        if (key == KeyCode.Backspace)
                        {
                            gameObject.SetActive(false);
                            return;
                        }
                        game.GetComponentInChildren<TextMeshProUGUI>().text = key.ToString();
                        game.GetComponent<SettingsInputButton>().key = key;
                        gameObject.SetActive(false);
                    }
                }
            }
        }
    }
}
