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
        this.death = GameObject.Find("奈落");
        SantaWidth = this.santa.GetComponent<RectTransform>().sizeDelta.x;
        Route5Width = this.route5.GetComponent<RectTransform>().sizeDelta.x;
    }

    // Update is called once per frame
    void Update()
    {
        float height = gameObject.GetComponent<SpriteRenderer>().bounds.size.y;
                // 自身の位置情報を tmp にコピーします。
        Vector3 santaPosition = this.santa.transform.position;
        Vector3 route5Position = this.route5.transform.position;
        Vector3 deathPosition = this.death.transform.position;
        Vector3 route1_1Position = this.route1_1.transform.position;
        // Debug.Log(santaPosition.x);
        // Debug.Log(route5Position.x);
        //  Debug.Log(santaPosition.y-1);
        //  Debug.Log(deathPosition.y+1.35); 
        //  Debug.Log(deathPosition.y+1.35); 
        //  Debug.Log(deathPosition.x);
        // Debug.Log(route1_1Position.y);
        float santaWidth = this.santa.GetComponent<Renderer>().bounds.size.x / 2f;
        float santaHeight = this.santa.GetComponent<Renderer>().bounds.size.y / 2f;
        float route5Width = this.route5.GetComponent<Renderer>().bounds.size.x / 2f;
        float route1_1Width = this.route1_1.GetComponent<Renderer>().bounds.size.x / 2f;
        float deathHeight = this.death.GetComponent<Renderer>().bounds.size.y / 2f;
    if (
        // santaPosition.x+0.6 >= route5Position.x-1.35 && santaPosition.x <= route5Position.x  && santaPosition.y == route5Position.y
        santaPosition.x + santaWidth >= route5Position.x - route5Width && santaPosition.x <= route5Position.x && santaPosition.y == route5Position.y
        ){
            RouteString = "5-2";

    }else if (santaPosition.x >= deathPosition.x  && santaPosition.y-santaHeight == deathPosition.y+deathHeight){
            RouteString = "5-0";
            Debug.Log("条件が満たされました");
            }
    // if (santaPosition.x+0.6 > route5Position.x-1.35 && santaPosition.y == route5Position.y){
    //         RouteString = "5-0";
    // }
    if (RouteString == "5-2"){
    //     float elapsedTime = Time.time;  // 追加
    //         float angle = elapsedTime * angularSpeed;

    // // 円弧上の位置を計算
    // float centerX = route5Position.x;  // route5 の X 座標を中心とします
    // float centerY = route5Position.y;  // route5 の Y 座標を中心とします
    // float x = centerX + Mathf.Cos(angle) * radius;
    // float y = centerY + Mathf.Sin(angle) * radius;

    // // 円弧上の位置に変化させます。
    // Vector3 santaArcPosition = new Vector3(x, y, 0f);

    // // 自身の位置情報を円弧上の位置に変更します。
    // this.santa.transform.position = santaArcPosition;

    // // 経過時間を更新
    // elapsedTime += Time.deltaTime;

    // // 条件が満たされたときの処理
    // Debug.Log("条件が満たされました");




        // 条件が満たされたときの処理
        // Debug.Log("条件が満たされました");
        // tmp の位置情報を、経過時間に応じて下方向に変化させます。
        santaPosition += Vector3.right * Time.deltaTime;
         santaPosition += Vector3.down *  Time.deltaTime;
        // santaPosition += Vector3.down *  Mathf.Pow(1,Time.deltaTime ) * 0.003f;
        // 自身の位置情報を tmp の位置情報に変更します。
        this.santa.transform.position = santaPosition;
    }else if(RouteString == "5-0"){
santaPosition += Vector3.right;
santaPosition += Vector3.down;
    }
    else if(RouteString == "0")
    {
        Debug.Log("条件が満たされませんでした");
          // tmp の位置情報を、経過時間に応じて下方向に変化させます。
        santaPosition += Vector3.right * Time.deltaTime;
        // 自身の位置情報を tmp の位置情報に変更します。
        this.transform.position = santaPosition;
    }
      
    }
}
