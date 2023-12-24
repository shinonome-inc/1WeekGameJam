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
    PositionValidater positionValidater = new PositionValidater();

    /// <summary>
    /// ランダムな座標に「わるいこ」を生成するメソッド
    /// </summary>
    public void GemerateBadChild()
    {
        GameObject santa = GameObject.FindGameObjectWithTag("Santa");
        // GameObject goodChild = GameObject.FindGameObjectWithTag("GoodChild");
        float distSanta = 1000.0f;
        float distGood = 1000.0f;

        if (santa != null)
        {
            // Santaオブジェクトとの距離が2以上になるように座標生成
            Vector3 randomPosition;
            float minDistance = 5.0f;
            do
            {
                float z = -1.0f;
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
                randomPosition = new Vector3(xOut, yOut, z);

                distSanta = Vector3.Distance(randomPosition, santa.transform.position);
                // distGood = Vector3.Distance(randomPosition, goodChild.transform.position);

            } while (distSanta < minDistance);
            // わるいこ生成
            GameObject badChild = Instantiate(badChildPrefab, randomPosition, Quaternion.identity);
            const float scale = 0.7f;
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
