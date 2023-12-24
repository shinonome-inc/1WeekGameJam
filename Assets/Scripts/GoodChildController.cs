using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// よいこオブジェクトを動かすためのController
/// </summary>
public class GoodChildController : MonoBehaviour
{
    public static Vector2 curPos;
    public static Vector3 swapMove = new Vector3(0.0f, 0.0f, 0.0f);
    // アニメーションのパラメータ
    public float minHeight = 1.0f;
    public float maxHeight = 1.2f;
    public float animationSpeed = 0.1f;

    // アニメーションの方向を管理するフラグ
    private bool isGrowing = true;

    void Animate()
    {
        // スケールを変更する
        float newHeight = transform.localScale.y + (isGrowing ? 1 : -1) * animationSpeed * Time.deltaTime;

        // スケールが一定範囲外になった場合、方向を切り替える
        if (newHeight < minHeight || newHeight > maxHeight)
        {
            isGrowing = !isGrowing;
        }

        // 新しいスケールを設定
        transform.localScale = new Vector3(transform.localScale.x, Mathf.Clamp(newHeight, minHeight, maxHeight), transform.localScale.z);
    }

    void Update()
    {
        // アニメーションの実行
        Animate();

        if (swapMove != new Vector3(0.0f, 0.0f, 0.0f))
        {
            transform.position += swapMove;
            swapMove = new Vector3(0.0f, 0.0f, 0.0f);
        }
        curPos = transform.position;
    }
}