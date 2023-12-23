using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class santaMove : MonoBehaviour
{
    GameObject santa;
    GameObject route1_1;
    GameObject route2;
    GameObject route3;
    GameObject route3_1;
    GameObject route3_2;
    GameObject route4;
    GameObject route4_1;
    GameObject route5;
    GameObject route5_1;
    GameObject route5_2;
    GameObject route5_3;
    GameObject route5_4;
    GameObject route5_5;
    GameObject route6;
    GameObject route6_1;
    GameObject death;
    float SantaWidth;
    float Route5Width;
    string RouteString = "0";
    public float radius = 2f;  // 円弧の半径
    public float angularSpeed = 1f;  // 角速度（1秒あたりの回転角度）

    private float elapsedTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        this.santa = GameObject.Find("Santa");
        this.route1_1 = GameObject.Find("route-1 (1)");
        this.route3 = GameObject.Find("route-3");
        this.route3_1 = GameObject.Find("route-3 (1)");
        this.route3_2 = GameObject.Find("route-3 (2)");
        this.route4 = GameObject.Find("route-4");
        this.route4_1 = GameObject.Find("route-4 (1)");
        this.route5 = GameObject.Find("route-5");
        this.route5_1 = GameObject.Find("route-5 (1)");
        this.route5_2 = GameObject.Find("route-5 (2)");
        this.route5_3 = GameObject.Find("route-5 (3)");
        this.route5_4 = GameObject.Find("route-5 (4)");
        this.route5_5 = GameObject.Find("route-5 (5)");
        this.route6 = GameObject.Find("route-6");
        this.route6_1 = GameObject.Find("route-6 (1)");
        this.death = GameObject.Find("DeathZone");
        SantaWidth = this.santa.GetComponent<RectTransform>().sizeDelta.x;
        Route5Width = this.route5.GetComponent<RectTransform>().sizeDelta.x;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Vector3 santaPosition = transform.position;
        Vector3 obstaclePosition = collision.transform.position;
        Vector3 relativePosition = obstaclePosition - santaPosition;
        if (collision.CompareTag("route5"))
        {
            // 相対位置に基づいて方向を判定
            if (Mathf.Abs(relativePosition.x) > Mathf.Abs(relativePosition.y))
            {
                // 左右の判定
                if (relativePosition.x > 0)
                {
                    Debug.Log("左側に接触");
                    // 右側に接触した場合の処理
                    RouteString = "5-2";
                }
                else if (relativePosition.x < 0)
                {
                    Debug.Log("右側に接触");
                    // 左側に接触した場合の処理
                    RouteString = "5-0";
                }
            }
            else
            {
                // 上下の判定
                if (relativePosition.y > 0)
                {
                    Debug.Log("下側に接触");
                    // 上側に接触した場合の処理
                    RouteString = "5-3";
                }
                else if (relativePosition.y < 0)
                {
                    Debug.Log("上側に接触");
                    // 下側に接触した場合の処理
                    RouteString = "5-1";
                }
            }
        }
        else if (collision.CompareTag("deathzone"))
        {
            // 相対位置に基づいて方向を判定
            if (Mathf.Abs(relativePosition.x) > Mathf.Abs(relativePosition.y))
            {
                // 左右の判定
                if (relativePosition.x > 0)
                {
                    Debug.Log("左側に接触");
                    // 右側に接触した場合の処理

                }
                else if (relativePosition.x < 0)
                {
                    Debug.Log("右側に接触");
                    // 左側に接触した場合の処理
                }
            }
            else
            {
                // 上下の判定
                if (relativePosition.y > 0)
                {
                    Debug.Log("下側に接触");
                    // 上側に接触した場合の処理

                }
                else if (relativePosition.y < 0)
                {
                    Debug.Log("上側に接触");
                    // 下側に接触した場合の処理

                }
            }
        }
        else if (collision.CompareTag("route1"))
        {
            // 相対位置に基づいて方向を判定
            if (Mathf.Abs(relativePosition.x) > Mathf.Abs(relativePosition.y))
            {
                // 左右の判定
                if (relativePosition.x > 0)
                {
                    Debug.Log("左側に接触");
                    // 右側に接触した場合の処理
                    RouteString = "1-0";
                }
                else if (relativePosition.x < 0)
                {
                    Debug.Log("右側に接触");
                    // 左側に接触した場合の処理
                    RouteString = "1-2";
                }
            }
            else
            {
                // 上下の判定
                if (relativePosition.y > 0)
                {
                    Debug.Log("下側に接触");
                    // 上側に接触した場合の処理
                    RouteString = "1-1";
                }
                else if (relativePosition.y < 0)
                {
                    Debug.Log("上側に接触");
                    // 下側に接触した場合の処理
                    RouteString = "1-3";
                }
            }
        }
        else if (collision.CompareTag("route3"))
        {
            // 相対位置に基づいて方向を判定
            if (Mathf.Abs(relativePosition.x) > Mathf.Abs(relativePosition.y))
            {
                // 左右の判定
                if (relativePosition.x > 0)
                {
                    Debug.Log("左側に接触");
                    // 右側に接触した場合の処理
                    RouteString = "3-1";
                }
                else if (relativePosition.x < 0)
                {
                    Debug.Log("右側に接触");
                    // 左側に接触した場合の処理
                    RouteString = "3-3";
                }
            }
            else
            {
                // 上下の判定
                if (relativePosition.y > 0)
                {
                    Debug.Log("下側に接触");
                    // 上側に接触した場合の処理
                    RouteString = "3-0";
                }
                else if (relativePosition.y < 0)
                {
                    Debug.Log("上側に接触");
                    // 下側に接触した場合の処理
                    RouteString = "3-2";
                }
            }
        }
        else if (collision.CompareTag("route4"))
        {
            // 相対位置に基づいて方向を判定
            if (Mathf.Abs(relativePosition.x) > Mathf.Abs(relativePosition.y))
            {
                // 左右の判定
                if (relativePosition.x < 0)
                {
                    Debug.Log("右側に接触");
                    // 左側に接触した場合の処理
                    RouteString = "4-0";
                }
            }
            else
            {
                // 上下の判定
                if (relativePosition.y < 0)
                {
                    Debug.Log("上側に接触");
                    // 下側に接触した場合の処理
                    RouteString = "4-1";
                }
            }
        }
        else if (collision.CompareTag("route6"))
        {
            // 相対位置に基づいて方向を判定
            if (Mathf.Abs(relativePosition.x) > Mathf.Abs(relativePosition.y))
            {
                // 左右の判定
                if (relativePosition.x > 0)
                {
                    Debug.Log("左側に接触");
                    // 右側に接触した場合の処理
                    RouteString = "6-1";
                }
                else if (relativePosition.x < 0)
                {
                    Debug.Log("右側に接触");
                    // 左側に接触した場合の処理
                    RouteString = "6-3";
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 santaPosition = this.santa.transform.position;
        Vector3 route5Position = this.route5.transform.position;
        Vector3 deathPosition = this.death.transform.position;
        Vector3 route1_1Position = this.route1_1.transform.position;
        if (RouteString == "5-2")
        {
            santaPosition += Vector3.right * Time.deltaTime;
            santaPosition += Vector3.down * Time.deltaTime;
            this.santa.transform.position = santaPosition;
        }
        else if (RouteString == "5-0")
        {
            santaPosition += Vector3.left * Time.deltaTime;
            santaPosition += Vector3.up * Time.deltaTime;
            this.santa.transform.position = santaPosition;
        }
        else if (RouteString == "5-3")
        {
            santaPosition += Vector3.left * Time.deltaTime;
            santaPosition += Vector3.up * Time.deltaTime;
            this.santa.transform.position = santaPosition;
        }
        else if (RouteString == "5-1")
        {
            santaPosition += Vector3.right * Time.deltaTime;
            santaPosition += Vector3.down * Time.deltaTime;
            this.santa.transform.position = santaPosition;
        }
        else if (RouteString == "1-0")
        {
            santaPosition += Vector3.right * Time.deltaTime;
            santaPosition += Vector3.up * Time.deltaTime;
            this.santa.transform.position = santaPosition;
        }
        else if (RouteString == "1-2")
        {
            santaPosition += Vector3.left * Time.deltaTime;
            santaPosition += Vector3.down * Time.deltaTime;
            this.santa.transform.position = santaPosition;
        }
        else if (RouteString == "1-1")
        {
            santaPosition += Vector3.right * Time.deltaTime;
            santaPosition += Vector3.up * Time.deltaTime;
            this.santa.transform.position = santaPosition;
        }
        else if (RouteString == "1-3")
        {
            santaPosition += Vector3.left * Time.deltaTime;
            santaPosition += Vector3.down * Time.deltaTime;
            this.santa.transform.position = santaPosition;
        }
        else if (RouteString == "3-1")
        {
            santaPosition += Vector3.right * Time.deltaTime;
            this.santa.transform.position = santaPosition;
        }
        else if (RouteString == "3-3")
        {
            santaPosition += Vector3.left * Time.deltaTime;
            this.santa.transform.position = santaPosition;
        }
        else if (RouteString == "3-0")
        {
            santaPosition += Vector3.up * Time.deltaTime;
            this.santa.transform.position = santaPosition;
        }
        else if (RouteString == "3-2")
        {
            santaPosition += Vector3.down * Time.deltaTime;
            this.santa.transform.position = santaPosition;
        }
        else if (RouteString == "4-0")
        {
            santaPosition += Vector3.left * Time.deltaTime;
            santaPosition += Vector3.up * Time.deltaTime;
            this.santa.transform.position = santaPosition;
        }
        else if (RouteString == "4-1")
        {
            santaPosition += Vector3.right * Time.deltaTime;
            santaPosition += Vector3.down * Time.deltaTime;
            this.santa.transform.position = santaPosition;
        }
        else if (RouteString == "6-1")
        {
            santaPosition += Vector3.right * Time.deltaTime;
            this.santa.transform.position = santaPosition;
        }
        else if (RouteString == "6-3")
        {
            santaPosition += Vector3.left * Time.deltaTime;
            this.santa.transform.position = santaPosition;
        }
        else
        {
            // tmp の位置情報を、経過時間に応じて下方向に変化させます。
            santaPosition += Vector3.right * Time.deltaTime;
            // 自身の位置情報を tmp の位置情報に変更します。
            this.transform.position = santaPosition;
        }
    }
}
