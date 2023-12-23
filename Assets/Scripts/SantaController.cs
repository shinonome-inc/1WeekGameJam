using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Constants;

/// <summary>
/// 仮のサンタオブジェクトを動かすためのスクリプトです。
/// </summary>
public class SantaController : MonoBehaviour
{
    void MoveObjectToMousePosition()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePosition;
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
        // TODO: クリック時ではなく常に一定速度で移動するように修正する。
        if (Input.GetMouseButtonDown(0))
        {
            MoveObjectToMousePosition();
        }
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
