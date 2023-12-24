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
    PositionValidater positionValidater = new PositionValidater();

    /// <summary>
    /// ランダムな座標に「よいこ」を生成するメソッド
    /// </summary>
    public void GemerateGoodChild()
    {
        float z = -1.0f;
        const float scale = 0.7f;

        // Validate
        float xOut = 0.0f;
        float yOut = 0.0f;
        bool isValid = false;
        // 10回まで生成して、生成できなかったら諦める Trueになったらループを抜ける
        for (int i = 0; i < 10; i++)
        {
            float x = CoordinateUtil.RandomPosX();
            float y = CoordinateUtil.RandomPosY();
            isValid = positionValidater.ValidateGenerationPosition(x, y, out xOut, out yOut);
            if (isValid)
            {
                break;
            }
        }

        GameObject go = Instantiate(goodChildPrefab) as GameObject;
        go.transform.position = new Vector3(xOut, yOut, z);
        go.transform.localScale = new Vector3(scale, scale, scale);
    }

    void Start()
    {
        GemerateGoodChild();
    }
}
