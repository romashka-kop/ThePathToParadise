using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ChangeLevelTrigger : MonoBehaviour
{
    private SaveDataScene _dataScene = new();

    private void OnTriggerEnter(Collider other)
    {
        _dataScene = _dataScene.Load<SaveDataScene>(_dataScene, "SceneData.json");
        if (other.gameObject.tag == "Player")
        {
            LiftNDrop.IsLift = false;
            _dataScene.IndexLvl = _dataScene.GetId() + 1;
            _dataScene.Calculate();
            _dataScene.Save(_dataScene, "SceneData.json");
            LoadingManager.SwitchSceneLoading(_dataScene.GetId());
        }
    }
}
