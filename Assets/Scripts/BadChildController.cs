using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Constants;

/// <summary>
/// わるいこオブジェクトを動かすためのController
/// </summary>
public class BadChildController : MonoBehaviour
{
    void MoveRandomly()
    {
        float moveSpeed = 100.0f;
        // ランダムな方向に動くベクトルを生成
        Vector2 randomDirection = new Vector2(Random.Range(-10f, 10f), Random.Range(-10f, 10f)).normalized;

        // ランダムな速度をかけて移動
        Vector2 newPosition = new Vector2(transform.position.x, transform.position.y) + randomDirection * moveSpeed * Time.deltaTime;

        newPosition.x = Mathf.Clamp(newPosition.x, Coordinates.minX, Coordinates.maxX);
        newPosition.y = Mathf.Clamp(newPosition.y, Coordinates.minY, Coordinates.maxY);

        // わるいこを新しい位置に移動
        transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
    }

    void Update()
    {
        MoveRandomly();
    }
}