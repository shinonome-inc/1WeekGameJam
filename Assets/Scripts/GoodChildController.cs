using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodChildController : MonoBehaviour
{
    // アニメーションのパラメータ
    public float minHeight = 1.0f;
    public float maxHeight = 1.2f;
    public float animationSpeed = 0.1f;

    // アニメーションの方向を管理するフラグ
    private bool isGrowing = true;

    void Update()
    {
        // アニメーションの実行
        Animate();
    }

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
}
