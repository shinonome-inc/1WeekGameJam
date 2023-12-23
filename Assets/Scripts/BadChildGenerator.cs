using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

/// <summary>
/// 「わるいこ」を生成するGenerator
/// </summary>
public class BadChildGenerator : MonoBehaviour
{
    public GameObject badChildPrefab;

    /// <summary>
    /// ランダムな座標に「わるいこ」を生成するメソッド
    /// </summary>
    public void GemerateBadChild()
    {
        float x = CoordinateUtil.RandomPosX();
        float y = CoordinateUtil.RandomPosY();
        const float scale = 1.0f;
        GameObject go = Instantiate(badChildPrefab) as GameObject;
        go.transform.position = new Vector2(x, y);
        go.transform.localScale = new Vector2(scale, scale);
    }

    void Start()
    {
        GemerateBadChild();
    }
}
