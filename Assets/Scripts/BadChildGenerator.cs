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
        GameObject santa = GameObject.FindGameObjectWithTag("Santa");

        if (santa != null)
        {
            // Santaオブジェクトとの距離が2以上になるように座標生成
            Vector3 randomPosition;
            float minDistance = 2.0f;
            do
            {
                float x = CoordinateUtil.RandomPosX();
                float y = CoordinateUtil.RandomPosY();
                float z = -1.0f;
                randomPosition = new Vector3(x, y, z);
            } while (Vector3.Distance(randomPosition, santa.transform.position) < minDistance);
            // わるいこ生成
            GameObject badChild = Instantiate(badChildPrefab, randomPosition, Quaternion.identity);
            const float scale = 1.0f;
            badChild.transform.localScale = new Vector3(scale, scale, scale);
        }
        else
        {
            Debug.LogError("Santa object not found.");
        }
    }

    void Start()
    {
        GemerateBadChild();
    }
}
