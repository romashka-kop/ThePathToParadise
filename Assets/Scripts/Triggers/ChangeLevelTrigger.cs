using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ChangeLevelTrigger : MonoBehaviour
{
    private SaveDataScene _dataScene = new();
    [SerializeField] StateTrigger _stateTrigger = StateTrigger.Level;

    private enum StateTrigger { Final, Final1, Level }

    private void OnTriggerEnter(Collider other)
    {
        _dataScene = _dataScene.Load<SaveDataScene>(_dataScene, "SceneData.json");
        if (other.gameObject.tag == "Player")
        {
            LiftNDrop.IsLift = false;
            MagnetRigidbody.IsMagnet = false;

            if (_stateTrigger == StateTrigger.Level)
                _dataScene.IndexLvl = _dataScene.GetId() + 1;
            else if (_stateTrigger == StateTrigger.Final)
                _dataScene.IndexLvl = 13;
            else if (_stateTrigger == StateTrigger.Final1)
                _dataScene.IndexLvl = 14;

            _dataScene.Calculate();
            _dataScene.Save(_dataScene, "SceneData.json");

            if(_dataScene.GetId() == 13 || _dataScene.GetId() == 14)
            {
                LoadingManager.SwitchSceneLoading(_dataScene.GetId());
            }
            else
            {
                LoadingManager.SwitchSceneLoading(15);
            }
        }
    }
}
