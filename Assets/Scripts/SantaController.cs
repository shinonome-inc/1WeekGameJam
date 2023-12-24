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
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f);
        // プレイヤーを移動させる
        transform.Translate(movement * moveSpeed * Time.deltaTime);
        // 位置更新の範囲制約
        float clampedX = Mathf.Clamp(transform.position.x, Coordinates.minX, Coordinates.maxX);
        float clampedY = Mathf.Clamp(transform.position.y, Coordinates.minY, Coordinates.maxY);
        transform.position = new Vector3(clampedX, clampedY, -1f);
    }

    void OnFinishedGame()
    {
        GameDirector gameDirector = GameObject.FindObjectOfType<GameDirector>();
        gameDirector.OnFinishedGame();
    }

    // サンタが「わるいこ」と衝突した場合
    void OnCollisionBadChild()
    {
        Debug.Log("Santa met " + Tags.badChildTag + ".");
        OnFinishedGame();
    }

    // サンタが「よいこ」と衝突した場合
    void OnCollisionGoodChild()
    {
        Debug.Log("Santa met " + Tags.goodChildTag + ".");
        float presentScore = 50.0f;
        ScoreManager.AddScore(presentScore);
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
        // TODO: 壁にぶつかった時の処理を追記する。
    }
}
