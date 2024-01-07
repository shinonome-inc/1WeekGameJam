using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Constants;

/// <summary>
/// サンタオブジェクトを動かすためのController
/// </summary>
public class SantaController : MonoBehaviour
{
    Animator animator;
    public static Vector2 befPos;
    public static Vector2 curPos;
    public static Vector2 nextPos;
    public static Vector2 nextPosNorm;
    public static GameObject worker;

    public delegate void PathRouteFunction(Vector2 curPosNorm, Vector2 befPosNorm, int vecInt, float speed, out Vector2 nextPosNorm, out bool isNext, out bool isOut);
    private PathRouteFunction pathRouteFunction;

    //　中心座標へのオフセット
    public static Vector3 offsetCenter = new Vector3(1.35f, 1.35f, 0f);

    public float speed;
    public bool isNext = false;
    public bool isOut = false;
    public int vecInt = 0;
    public string arrayName;
    public static int posX = 2; // 今のX
    public static int posY = 1; // 今のY
    public static Vector3 swapMove = new Vector3(0.0f, 0.0f, 0.0f);

    // サンタを移動させる
    public void MoveSanta(Vector3 PosDelta)
    {
        // worker = GameObject.Find("worker");
        transform.position += PosDelta;
    }

    void MoveSantaByKeyboard()
    {
        float moveSpeed = 5.0f;
        // 上下左右のキー入力を取得
        Vector2 currntPos = transform.position;
        int posX_, posY_;
        TilePath.GetTileNumber(currntPos, out posX_, out posY_);
        Vector2 normCurPos = TilePath.GetNormalizedPos(currntPos);
        Debug.Log("Santa position: " + currntPos + " Tile position: " + posX_ + " " + posY_ + " Normalized position: " + normCurPos);

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        // 移動ベクトルを作成
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f);
        // プレイヤーを移動させる
        transform.Translate(movement * moveSpeed * Time.deltaTime);
        // 位置更新の範囲制約
        float clampedX = Mathf.Clamp(transform.position.x, Coordinates.minX, Coordinates.maxX);
        float clampedY = Mathf.Clamp(transform.position.y, Coordinates.minY, Coordinates.maxY);
        transform.position = new Vector3(clampedX, clampedY, -1f);
    }

    void OnFinishedGame()
    {
        GameDirector gameDirector = GameObject.FindObjectOfType<GameDirector>();
        gameDirector.OnFinishedGame();
    }

    // サンタが「わるいこ」と衝突した場合
    void OnCollisionBadChild()
    {
        Debug.Log("Santa met " + Tags.badChildTag + ".");
        BadChildController.PlaySE();
        OnFinishedGame();
    }

    // サンタが「よいこ」と衝突した場合
    void OnCollisionGoodChild()
    {
        Debug.Log("Santa met " + Tags.goodChildTag + ".");
        float presentScore = 50.0f;
        ScoreManager.AddScore(presentScore);
        GameObject goodChild = GameObject.FindGameObjectWithTag(Tags.goodChildTag);
        GameObject badChild = GameObject.FindGameObjectWithTag(Tags.badChildTag);
        Destroy(goodChild);
        Destroy(badChild);
        GoodChildGenerator goodChildGenerator = GameObject.FindObjectOfType<GoodChildGenerator>();
        BadChildGenerator badChildGenerator = GameObject.FindObjectOfType<BadChildGenerator>();
        goodChildGenerator.GemerateGoodChild();
        badChildGenerator.GemerateBadChild();
    }

    // タイルの名前からパスルート関数を設定する
    private void SetPathRouteFunction(string input)
    {
        switch (input)
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

    // Start is called before the first frame update
    void Start()
    {
        // speed
        speed = 0.00004f;
        // worker = GameObject.Find("worker");

        // 現在位置を取得
        curPos = transform.position; // - offsetCenter;
        befPos = curPos - new Vector2(0.0f, -0.1f);
        vecInt = CalcIntNum(befPos, curPos);

        int posX_, posY_;
        TilePath.GetTileNumber(curPos, out posX_, out posY_);
        arrayName = tilescript.GetStringArrayElement(posX, posY);
        // Debug.Log("posX :" + posX + " posY :" + posY + " arrayName :" + arrayName + " CurPos :" + curPos);
    }

    void Update()
    {
        if (swapMove != new Vector3(0.0f, 0.0f, 0.0f))
        {
            MoveSanta(swapMove);
            swapMove = new Vector3(0.0f, 0.0f, 0.0f);
        }

        curPos = transform.position;// - offsetCenter;

        Vector2 befPosNorm = TilePath.GetNormalizedPos(befPos);
        Vector2 curPosNorm = TilePath.GetNormalizedPos(curPos);
        // Debug.Log("befPosNorm :" + befPosNorm + " curPosNorm :" + curPosNorm);

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
            transform.position += TilePath.GetWorldPos(nextPosNorm);
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
                    transform.position += new Vector3(0.1f, 0.0f, 0.0f);
                    break;
                case 2:
                    posY += 1;
                    transform.position += new Vector3(0.0f, 0.1f, 0.0f);
                    break;
                case 3:
                    posX -= 1;
                    transform.position += new Vector3(-0.1f, 0.0f, 0.0f);
                    break;
                case 4:
                    posY -= 1;
                    transform.position += new Vector3(0.0f, -0.1f, 0.0f);
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(Tags.badChildTag))
        {
            OnCollisionBadChild();
        }
        else if (other.gameObject.CompareTag(Tags.goodChildTag))
        {
            OnCollisionGoodChild();
        }
        // TODO: 壁にぶつかった時の処理を追記する。
    }
}
