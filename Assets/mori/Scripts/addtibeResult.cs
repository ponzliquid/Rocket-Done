using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// リザルト
/// </summary>
public class addtibeResult : MonoBehaviour
{

    /// <summary>
    /// リザルトを呼び出す
    /// </summary>
    public void GoToResult()
    {
        // additiveに呼び出す。
        SceneManager.LoadScene("resultScene", LoadSceneMode.Additive);
	}

    public void OnClickFinishResult(){
        // resultSceneを開放
        SceneManager.UnloadSceneAsync("resultScene");
        SceneManager.LoadScene("titleScene");
    }

    public void OnClickRetry(){
        SceneManager.UnloadSceneAsync("resultScene");
        SceneManager.LoadScene(0);
    }
}