using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Constants;

public class FuckinSanta : MonoBehaviour
{
    public static Vector2 befPos;
    public static Vector2 curPos;
    public static Vector2 nextPos;
    public static Vector2 nextPosNorm;
    public static GameObject worker;


    public delegate void PathRouteFunction(Vector2 curPosNorm, Vector2 befPosNorm, int vecInt, float speed, out Vector2 nextPosNorm, out bool isNext, out bool isOut);
    private PathRouteFunction pathRouteFunction;

    //　中心座標へのオフセット
    public static Vector3 offsetCenter = new Vector3(1.35f, 1.35f, 0f);

    public float speed = 1e-9f*10;
    public bool isNext = false;
    public bool isOut = false;
    public int vecInt = 0;
    public string arrayName;
    public static int posX = 0; // 今のX
    public static int posY = 2; // 今のY


    // Start is called before the first frame update
    void Start()
    {
        // speed
        speed = 0.000001f;
        worker = GameObject.Find("worker");

        // 現在位置を取得
        curPos = worker.transform.position; // - offsetCenter;
        befPos = curPos - new Vector2(0.0f, -0.1f);
        vecInt = CalcIntNum(befPos, curPos);

        // int posX_, posY_;
        // TilePath.GetTileNumber(curPos, out posX_, out posY_);
        arrayName = tilescript.GetStringArrayElement(posX, posY);
        // Debug.Log("posX :" + posX + " posY :" + posY + " arrayName :" + arrayName + " CurPos :" + curPos);
    }

    // Update is called once per frame
    void Update()
    {
        curPos = worker.transform.position;// - offsetCenter;


        Vector2 befPosNorm = TilePath.GetNormalizedPos(befPos);
        Vector2 curPosNorm = TilePath.GetNormalizedPos(curPos);
        //Debug.Log("befPosNorm :" + befPosNorm + " curPosNorm :" + curPosNorm);

        // SetPathRouteFunction
        SetPathRouteFunction(arrayName);
        pathRouteFunction(curPosNorm, befPosNorm, vecInt, speed, out nextPosNorm, out isNext, out isOut);
        // debug
        // Debug.Log("nextPosNorm :" + nextPosNorm + " isNext :" + isNext + " isOut :" + isOut);

        if (isOut == true)
        {
            // Debug.Log("isOut");
            OnFinishedGame();
            return;
        }

        // Move
        if (isNext == false)
        {
            worker.transform.position += TilePath.GetWorldPos(nextPosNorm);
        }
        else
        {
            vecInt = CalcIntNum(befPos, curPos);

            // Next Tile
            // TilePath.GetTileNumber(curPos, out posX, out posY);
            // Vector2 curPos2 = curPos;
            switch (vecInt) // ecint →↑←↓の順に1234
            {
                case 1:
                    posX += 1;
                    worker.transform.position += new Vector3(0.1f, 0.0f, 0.0f);
                    break;
                case 2:
                    posY += 1;
                    worker.transform.position += new Vector3(0.0f, 0.1f, 0.0f);
                    break;
                case 3:
                    posX -= 1;
                    worker.transform.position += new Vector3(-0.1f, 0.0f, 0.0f);
                    break;
                case 4:
                    posY -= 1;
                    worker.transform.position += new Vector3(0.0f, -0.1f, 0.0f);
                    break;
                default:
                    break;
            }
            arrayName = tilescript.GetStringArrayElement(posX, posY);
            // Debug.Log("posX :" + posX + " posY :" + posY + " arrayName :" + arrayName + " CurPos :" + curPos + " vecInt :" + vecInt);
        }
        befPos = curPos;
        //
    }

    // ゲームを終了する
    public static void OnFinishedGame()
    {
        SceneManager.LoadScene("3.result");
    }

    // サンタを移動させる
    public static void MoveSanta(Vector3 PosDelta)
    {
        worker = GameObject.Find("worker");
        worker.transform.position += PosDelta;
    }

    // タイルの名前からパスルート関数を設定する
    private void SetPathRouteFunction(string input)
    {
        switch(input)
        {
            case "R1":
                pathRouteFunction = TilePath.GetPathRoute1;
                break;
            case "R2":
                pathRouteFunction = TilePath.GetPathRoute2;
                break;
            case "R3":
                pathRouteFunction = TilePath.GetPathRoute3;
                break;
            case "R4":
                pathRouteFunction = TilePath.GetPathRoute4;
                break;
            case "R5":
                pathRouteFunction = TilePath.GetPathRoute5;
                break;
            case "R6":
                pathRouteFunction = TilePath.GetPathRoute6;
                break;
            default:
                pathRouteFunction = TilePath.GetPathRoute0;
                break;
        }
    }

    // サンタの移動ベクトルを計算する
    public int CalcIntNum(Vector2 befPos, Vector2 curPos)
    {
        // vecint →↑←↓の順に1234
        Vector2 vecInt = curPos - befPos;
        //正規化してthetaを求める
        Vector2 vecIntNorm = vecInt.normalized;
        float theta = Mathf.Atan2(vecIntNorm.y, vecIntNorm.x);
        //ラジアンから度に変換
        theta = theta * 180 / Mathf.PI;
        // 0 ~ 360にする
        theta = theta % 360;
        if (theta < 0)
        {
            theta += 360;
        }
        // Debug.Log(theta);

        // 0~360を0~4にする: -45~45→1, 45~135→2, 135~225→3, 225~315→4, 315~360→1
        int intNum = 0;
        if (theta >= -45 && theta < 45)
        {
            intNum = 1;
        }
        else if (theta >= 45 && theta < 135)
        {
            intNum = 2;
        }
        else if (theta >= 135 && theta < 225)
        {
            intNum = 3;
        }
        else if (theta >= 225 && theta < 315)
        {
            intNum = 4;
        }
        else if (theta >= 315 && theta < 360)
        {
            intNum = 1;
        }

        return intNum;
    }

}
