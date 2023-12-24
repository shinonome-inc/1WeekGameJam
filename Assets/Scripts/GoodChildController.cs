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

    void Start()
    {

    }

    void Update()
    {
        if (swapMove != new Vector3(0.0f, 0.0f, 0.0f))
        {
            transform.position += swapMove;
            swapMove = new Vector3(0.0f, 0.0f, 0.0f);
        }
        curPos = transform.position;
    }
}
