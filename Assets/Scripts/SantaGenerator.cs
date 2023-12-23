using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// サンタオブジェクトを生成するためのGenerator
/// </summary>
public class SantaGenerator : MonoBehaviour
{
    /// <summary>
    /// サンタオブジェクトを生成するメソッド
    /// </summary>
    public GameObject santaPrefab;
    public void GemerateSanta()
    {
        float x = 0;
        float y = 0;
        const float scale = 1.0f;
        GameObject go = Instantiate(santaPrefab) as GameObject;
        go.transform.position = new Vector2(x, y);
        go.transform.localScale = new Vector2(scale, scale);
    }

    void Start()
    {
        GemerateSanta();
    }
}