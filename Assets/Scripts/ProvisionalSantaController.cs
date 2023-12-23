using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 仮のサンタオブジェクトを動かすためのスクリプトです。
public class ProvisionalSanta : MonoBehaviour
{
    void MoveObjectToMousePosition()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePosition;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MoveObjectToMousePosition();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        string goodChildTag = "GoodChild";
        string badChildTag = "BadChild";
        // サンタが「わるいこ」と衝突した場合
        if (other.gameObject.CompareTag(badChildTag))
        {
            Debug.Log("Santa met " + badChildTag + ".");
            // TODO: ゲームオーバーの処理を追加する。
        }
        // サンタが「よいこ」と衝突した場合
        else if (other.gameObject.CompareTag(goodChildTag))
        {
            Debug.Log("Santa met " + goodChildTag + ".");
            GameObject goodChild = GameObject.FindGameObjectWithTag(goodChildTag);
            GameObject badChild = GameObject.FindGameObjectWithTag(badChildTag);
            Destroy(goodChild);
            Destroy(badChild);
        }
    }
}
