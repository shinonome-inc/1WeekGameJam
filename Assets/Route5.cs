using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Route5 : MonoBehaviour
{
    GameObject santa;
    GameObject route5;
    string RouteString = "0";
    int movedRoute = 0;
    Vector3 lastPosition;
    // Start is called before the first frame update
    void Start()
    {
        this.santa = GameObject.Find("Santa");
        this.route5 = GameObject.Find("route-5");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 santaPosition = this.santa.transform.position;
        Vector3 currentPosition = this.route5.transform.position;
        // 位置が変わったかをチェック
        if (currentPosition != lastPosition)
        {
            // 移動量を計算
            Vector3 movement = currentPosition - lastPosition;
            this.santa.transform.position = santaPosition + movement;
            // 最後の位置を更新
            lastPosition = currentPosition;
        }
    }
}
