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
        float z = -1.0f;
        const float scale = 0.7f;
        GameObject go = Instantiate(santaPrefab) as GameObject;
        go.transform.position = new Vector3(x, y, z);
        go.transform.localScale = new Vector3(scale, scale, scale);
    }

    void Start()
    {
        GemerateSanta();
    }
}
