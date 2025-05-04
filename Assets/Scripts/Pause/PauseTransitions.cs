using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class PauseTransitions : MonoBehaviour
{
    [SerializeField]
    private Button _buttonContinue;

    [SerializeField]
    private Button _buttonSettings;

    [SerializeField]
    private Button _buttonExit;

    [SerializeField]
    private GameObject _settings;

    private Animator _animatorPause;
    private Animator _animatorSettings;

    void Start()
    {
        Init();
    }

    private void Init()
    {
        _animatorPause = GetComponent<Animator>();
        _animatorSettings = _settings.GetComponent<Animator>();
        _buttonContinue.onClick.AddListener(Continue);
        _buttonSettings.onClick.AddListener(OpenSettings);
        _buttonExit.onClick.AddListener(ExitMenu);
    }

    private void Continue()
    {
        _animatorPause.SetTrigger("ClosePause");
        ClosePausePanel();
        ChangePauseMode(CursorLockMode.Locked ,false, 1);
    }

    private void OpenSettings()
    {
        _settings.SetActive(true);
        _animatorSettings.SetTrigger("OpenSettingsTrigger");
    }

    private void ExitMenu()
    {
        ChangePauseMode(CursorLockMode.None,true, 1);
        LoadingManager.SwitchSceneLoading(0);
        MenuManager.IsMenu = false;
    }

    private async void ClosePausePanel()
    {
        await Task.Delay(1000);
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public static void ChangePauseMode(CursorLockMode lockMode ,bool visable, float timeScale)
    {
        Cursor.lockState = lockMode;
        Cursor.visible = visable;
        Time.timeScale = timeScale;
    }
}
