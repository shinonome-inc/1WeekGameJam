// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class DeathZone : MonoBehaviour
// {
//     // Start is called before the first frame update
//     GameObject santa;
//     GameObject death;
//     string RouteString = "0";
//     void Start()
//     {
//         this.santa = GameObject.Find("Santa");
//         this.death = GameObject.Find("DeathZone");
//     }

//                  void OnTriggerEnter2D(Collider2D collision)
//     {
//             Vector3 santaPosition = transform.position;
// Vector3 obstaclePosition = collision.transform.position;
// Vector3 relativePosition = obstaclePosition - santaPosition;
//          if(collision.CompareTag("deathzone")) {
//              Debug.Log("deathzoneに接触");
// // 相対位置に基づいて方向を判定
// if (Mathf.Abs(relativePosition.x) > Mathf.Abs(relativePosition.y))
// {
//     // 左右の判定
//     if (relativePosition.x > 0)
//     {
//         Debug.Log("左側に接触");
//         // 右側に接触した場合の処理
//     }
//     else if (relativePosition.x < 0)
//     {
//         Debug.Log("右側に接触");
//         // 左側に接触した場合の処理
//     }
//     else
//     {
//         Debug.Log("正面に接触");
//         // 正面に接触した場合の処理
//     }
// }
// else
// {
//     // 上下の判定
//     if (relativePosition.y > 0)
//     {
//         Debug.Log("上側に接触");
//         // 上側に接触した場合の処理
//     }
//     else if (relativePosition.y < 0)
//     {
//         Debug.Log("下側に接触");
//         // 下側に接触した場合の処理
//     }
//     else
//     {
//         Debug.Log("正面に接触");
//         // 正面に接触した場合の処理
//     }
// }}
//     }

//   void OnTriggerStay2D(Collider2D collision)
//     {
//       if(collision.CompareTag("route5")){
//                 // サンタと接触したオブジェクトの位置情報を取得
//         Vector3 santaPosition = transform.position;
//         Vector3 obstaclePosition = collision.transform.position;

//         // オブジェクトとの相対位置を計算
//         Vector3 relativePosition = obstaclePosition - santaPosition;

//         // 相対位置に基づいて方向を判定
//         if (relativePosition.x > 0)
//         {
//             // Debug.Log("右側に接触");
//             // 右側に接触した場合の処理
//         }
//         else if (relativePosition.x < 0)
//         {
//             // Debug.Log("左側に接触");
//             // 左側に接触した場合の処理
//         }
//         else
//         {
//             // Debug.Log("正面に接触");
//             // 正面に接触した場合の処理
//         }

//         RouteString = "5-2";
//       }
//     }

//     // Update is called once per frame
//     void Update()
//     {

//     }
// }
