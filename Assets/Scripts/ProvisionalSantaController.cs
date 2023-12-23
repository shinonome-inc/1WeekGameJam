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
}
