using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingManager : MonoBehaviour
{
    public Image LoadBar;

    private AsyncOperation _asyncOperation;

    //void Start()
    //{
    //    StartCoroutine(Loading());
    //}

    //private IEnumerator Loading()
    //{
    //    //Debug.Log("�������� �����");
    //    //yield return new WaitForSeconds(1);

    //    //MenuManager.DataScene.IndexLvl += 1;
    //    //_asyncOperation = SceneManager.LoadSceneAsync(MenuManager.DataScene.IndexLvl);
    //    //while (_asyncOperation.isDone)
    //    //{
    //    //    Debug.Log("����");
    //    //    LoadBar.fillAmount = _asyncOperation.progress / 0.9f;
    //    //    Debug.Log(LoadBar.fillAmount);
    //    //    yield return null;
    //    //}
    //}
}
