using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Timeline.AnimationPlayableAsset;

public class FinalManager : MonoBehaviour
{
    [SerializeField] Button _buttonToRoma;
    [SerializeField] Button _buttonToKirill;
    [SerializeField] Button _buttonToDanill;
    [SerializeField] Button _buttonToMenu;

    private const string _urlRoma = "https://vk.com/romashkaaaa_a";
    private const string _urlKirill = "https://web.telegram.org/a/#-1001617083906";
    private const string _urlDanill = "https://t.me/seraaworld";
    private SaveDataScene _dataScene = new();

    private bool _isMenu = true;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        _buttonToRoma.onClick.AddListener(ClickToRoma);
        _buttonToKirill.onClick.AddListener(ClickToKirill);
        _buttonToDanill.onClick.AddListener(ClickToDanill);
        _buttonToMenu.onClick.AddListener(ClickToMenu);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        _dataScene.IndexLvl = 12;
        _dataScene.Calculate();
        _dataScene.Save(_dataScene, "SceneData.json");
    }

    private void ClickToMenu()
    {
        if (_isMenu)
        {
            _isMenu = false;
            LoadingManager.SwitchSceneLoading(0);
        }
    }

    private void ClickToRoma()
    {
        Application.OpenURL(_urlRoma);
    }

    private void ClickToKirill()
    {
        Application.OpenURL(_urlKirill);
    }

    private void ClickToDanill()
    {
        Application.OpenURL(_urlDanill);
    }
}
