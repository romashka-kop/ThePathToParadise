using TMPro;
using UnityEngine;

public class StoryManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textStory;

    private SaveDataScene _scene = new();
    private StoryCollection _storyCollection = new();
    private bool _isRead = true;

    void Start()
    {
        _scene = _scene.Load<SaveDataScene>(_scene, "SceneData.json");
        _storyCollection = _storyCollection.Load<StoryCollection>(_storyCollection, "StoryJSON");
        _textStory.text = _storyCollection.paragraphs[_scene.GetId() - 1].ToString();
    }

    void Update()
    {
        if (Input.anyKeyDown && _isRead)
        {
            _isRead = false;
            LoadingManager.SwitchSceneLoading(_scene.GetId());
        }
    }
}
