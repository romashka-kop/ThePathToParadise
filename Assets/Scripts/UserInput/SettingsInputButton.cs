using UnityEngine;

public class SettingsInputButton : MonoBehaviour
{
    public enum MoveDirection {Forward, Back, Left, Right, Jump, Squat, Take, Drop, ForceDrop };

    public MoveDirection direction;

    public GameObject panelInput;

    public KeyCode key;

    public void ClickToInputUserKey()
    {
        UserInputKey.game = gameObject;
        panelInput.SetActive(true);
    }
}
