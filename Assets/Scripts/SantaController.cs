using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Constants;

/// <summary>
/// サンタオブジェクトを動かすためのController
/// </summary>
public class SantaController : MonoBehaviour
{
    private float moveSpeed = 5.0f;
    void MoveSanta()
    {
        // 上下左右のキー入力を取得
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        // 移動ベクトルを作成
        Vector2 movement = new Vector2(horizontalInput, verticalInput);
        // プレイヤーを移動させる
        transform.Translate(movement * moveSpeed * Time.deltaTime);
    }

    // サンタが「わるいこ」と衝突した場合
    void OnCollisionBadChild()
    {
        Debug.Log("Santa met " + Tags.badChildTag + ".");
        // TODO: ゲームオーバーの処理を追加する。
    }

    // サンタが「よいこ」と衝突した場合
    void OnCollisionGoodChild()
    {
        Debug.Log("Santa met " + Tags.goodChildTag + ".");
        GameObject goodChild = GameObject.FindGameObjectWithTag(Tags.goodChildTag);
        GameObject badChild = GameObject.FindGameObjectWithTag(Tags.badChildTag);
        Destroy(goodChild);
        Destroy(badChild);
        GoodChildGenerator goodChildGenerator = GameObject.FindObjectOfType<GoodChildGenerator>();
        BadChildGenerator badChildGenerator = GameObject.FindObjectOfType<BadChildGenerator>();
        goodChildGenerator.GemerateGoodChild();
        badChildGenerator.GemerateBadChild();
    }

    void Update()
    {
        // TODO: 十字キー入力時ではなく常に一定速度で移動するように修正する。
        MoveSanta();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(Tags.badChildTag))
        {
            OnCollisionBadChild();
        }
        else if (other.gameObject.CompareTag(Tags.goodChildTag))
        {
            OnCollisionGoodChild();
        }
    }
}
