using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSoundControll : MonoBehaviour
{
    [SerializeField] AudioSource _audio;
    private Button[] buttonsScene;

    private void Start()
    {
        buttonsScene = Resources.FindObjectsOfTypeAll<Button>().Where(button => button.gameObject.scene == gameObject.scene).ToArray();
        foreach (Button button in buttonsScene)
            button.onClick.AddListener(PlaySoundClick);
    }
    private void PlaySoundClick()
    {
        _audio.Play();
    }
}
