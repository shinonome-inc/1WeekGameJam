using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ゲーム全体の動きを管理するスクリプト
/// </summary>
public class GameDirector : MonoBehaviour
{
    /// <summary>
    /// ゲームオーバー時にResult Sceneに遷移するメソッド
    /// </summary>
    public void OnFinishedGame()
    {
        SceneManager.LoadScene("3.result");
    }

    void Start()
    {

    }

    void Update()
    {

    }
}
