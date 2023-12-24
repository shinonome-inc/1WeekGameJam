using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// わるいこオブジェクトを動かすためのController
/// </summary>
public class BadChildController : MonoBehaviour
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
