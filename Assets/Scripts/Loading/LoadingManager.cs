using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingManager : MonoBehaviour
{
    public TextMeshProUGUI LoadingText;
    public Image ProgressImage;

    private static LoadingManager instance;

    private Animator _animator;

    private AsyncOperation _operation;

    private static bool isPlayCloasingAnim = false;

    private void Awake()
    {
        instance = this;
        _animator = GetComponent<Animator>();

        if (isPlayCloasingAnim)
            instance._animator.SetTrigger("sceneEnd");
    }

    private void Update()
    {
        if (_operation != null)
        {
            LoadingText.text = Mathf.RoundToInt(instance._operation.progress * 100) + "%";
            ProgressImage.fillAmount = instance._operation.progress;
        }
    }

    public static void SwitchSceneLoading(int idScene)
    {
        instance._animator.SetTrigger("sceneStart");

        instance._operation = SceneManager.LoadSceneAsync(idScene);
        instance._operation.allowSceneActivation = false;
    }

    public void OnAnimationOver()
    {
        isPlayCloasingAnim = true;
        instance._operation.allowSceneActivation = true;
    }
}
