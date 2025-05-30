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

    private bool _isMenu = true;

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
        MusicGameControll.Audio.Stop();
    }

    private void Continue()
    {
        MusicGameControll.Audio.Play();
        Pause.IsPause = false;
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
        if (_isMenu)
        {
            _isMenu = false;
            Pause.IsPause = false;
            LiftNDrop.IsLift = false;
            MagnetRigidbody.IsMagnet = false;
            LoadingManager.SwitchSceneLoading(0);
            SetParametrsExitToMenu();
        }
    }

    private async void SetParametrsExitToMenu()
    {
        await Task.Delay(1000);
        ChangePauseMode(CursorLockMode.None, true, 1);
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
