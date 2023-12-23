using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

/// <summary>
/// 「よいこ」を生成するGenerator
/// </summary>
public class GoodChildGenerator : MonoBehaviour
{
    public GameObject goodChildPrefab;

    /// <summary>
    /// ランダムな座標に「よいこ」を生成するメソッド
    /// </summary>
    public void GemerateGoodChild()
    {
        float x = CoordinateUtil.RandomPosX();
        float y = CoordinateUtil.RandomPosY();
        const float scale = 1.0f;
        GameObject go = Instantiate(goodChildPrefab) as GameObject;
        go.transform.position = new Vector2(x, y);
        go.transform.localScale = new Vector2(scale, scale);
    }

    void Start()
    {
        GemerateGoodChild();
    }
}
