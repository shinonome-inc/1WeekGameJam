using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class TilePath : MonoBehaviour
{
    public static AudioSource audioSource;
    // 左下、右上の座標を入力
    // public static Vector2 leftDownPos = new Vector2(-5.38f, -3.40f);
    // public static Vector2 rightUpPos = new Vector2(5.42f, 2.20f);
    public static Vector2 leftDownPos = new Vector2(-6.72f, -4.00f);
    public static Vector2 rightUpPos = new Vector2(6.69f, 3.54f);
    public static float tileWidth = 0f;
    public static float tileHeight = 0f;
    public static float singleTileWidth = 2.7f;
    public static float singleTileHeight = 2.7f;

    public Vector2 convertPos;

    GameObject route1_1;
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

    /// <summary>
    /// SEを鳴らすメソッド
    /// </summary>
    public static void PlaySE()
    {
        audioSource.Play();
    }


    // Start is called before the first frame update
    void Start()
    {
        // init
        convertPos = new Vector2(tileWidth / 2, tileHeight / 2);
        rightUpPos += new Vector2(singleTileWidth, singleTileHeight);
        tileWidth = rightUpPos.x - leftDownPos.x;
        tileHeight = rightUpPos.y - leftDownPos.y;

        // debug
        // Debug.Log("TilePath.cs");
        this.route1_1 = GameObject.Find("route-1 (1)");
        this.route3 = GameObject.Find("route-3");
        this.route3_1 = GameObject.Find("route-3 (1)");
        this.route3_2 = GameObject.Find("route-3 (2)");
        this.route4 = GameObject.Find("route-4");
        this.route5 = GameObject.Find("route-5");
        this.route5_1 = GameObject.Find("route-5 (1)");
        this.route5_2 = GameObject.Find("route-5 (2)");
        this.route5_3 = GameObject.Find("route-5 (3)");
        this.route5_4 = GameObject.Find("route-5 (4)");
        this.route5_5 = GameObject.Find("route-5 (5)");
    }

    // Update is called once per frame
    // void Update()
    // {
    //     // route1_1の中心位置を取得
    //     Vector2 tmp = this.route1_1.transform.position;
    //     // route3の中心位置を取得
    //     Vector2 tmp2 = this.route5.transform.position;
    //     Vector2 tmp3 = this.route5_1.transform.position;
    //     Vector2 tmp4 = this.route5_2.transform.position;
    //     Vector2 tmp5 = this.route5_3.transform.position;
    //     Vector2 tmp6 = this.route5_4.transform.position;
    //     Vector2 tmp7 = this.route5_5.transform.position;
    //     //debug
    //     // Debug.Log(tmp + ", " + tmp2 + ", " + tmp3 + ", " + tmp4 + ", " + tmp5 + ", " + tmp6 + ", " + tmp7);

    //     int x, y;
    //     bool tileNum = GetTileNumber(tmp, out x, out y);
    //     // Debug.Log(x + ", " + y);
    // }

    // 現在の座標番号を計算 5*3のマス目の中で何番目にいるか　ポインタでx,yを返す
    public static bool GetTileNumber(Vector2 vec, out int x, out int y)
    {
        // 範囲外の場合はfalseを返す
        if (vec.x < leftDownPos.x || vec.x > rightUpPos.x ||
            vec.y < leftDownPos.y || vec.y > rightUpPos.y)
        {
            x = 0;
            y = 0;
            return false;
        }
        else
        {
            // 現在の座標番号を計算 5*3のマス目の中で何番目にいるか
            x = (int)((vec.x - leftDownPos.x) / singleTileWidth);
            y = (int)((vec.y - leftDownPos.y) / singleTileHeight);

            // 現在の座標番号を返す
            return true;
        }
    }

    // 今いる場所を正規化して返す
    public static Vector2 GetNormalizedPos(Vector2 vec)
    {
        float x = (vec.x - leftDownPos.x) % singleTileWidth;
        float y = (vec.y - leftDownPos.y) % singleTileHeight;

        // 1マスの中での位置を返す
        float normalizedX = (x / singleTileWidth - 1e-7f) % 1f;
        float normalizedY = (y / singleTileHeight - 1e-7f) % 1f;

        // 0.5ずつ足す
        // normalizedX += 0.5f;
        normalizedY += 0.2f; // 0.5 bef
        // 正規化
        normalizedX = (normalizedX < 0) ? 1 + normalizedX : normalizedX;
        normalizedY = (normalizedY < 0) ? 1 + normalizedY : normalizedY;

        normalizedX = (normalizedX > 1) ? normalizedX - 1 : normalizedX;
        normalizedY = (normalizedY > 1) ? normalizedY - 1 : normalizedY;


        return new Vector2(normalizedX, normalizedY);
    }

    // ワールド座標に変換（かけるだけ）
    public static Vector3 GetWorldPos(Vector2 vec)
    {
        float worldX = vec.x * singleTileWidth;
        float worldY = vec.y * singleTileHeight;

        return new Vector3(worldX, worldY, 0f);
    }

    // route0のパスについて
    public static void GetPathRoute0(Vector2 Pos, Vector2 BefPos, int inputNum, float speed, out Vector2 moveMent, out bool isNext, out bool isOut)
    {
        isOut = true;
        isNext = false;
        moveMent = new Vector2(0, 0);
    }

    // route1のパスについて
    public static void GetPathRoute1(Vector2 Pos, Vector2 BefPos, int inputNum, float speed, out Vector2 moveMent, out bool isNext, out bool isOut)
    {
        // vecint →↑←↓の順に1234
        // 道1: 出入り口(0, 0.5), 出入り口(0.5, 1)
        // 道2: 出入り口(0.5, 0.0), 出入り口(1, 0.5)

        // 道1の場合斜めに進む
        // 道2の場合斜めに進む
        //　向きの計算
        isOut = false;
        Vector2 goal = new Vector2(0, 0);

        // Switch文で場合分け
        switch (inputNum)
        {
            case 1: // 出口は(0.5, 1);
                goal = new Vector2(0.5f, 1.01f);
                break;
            case 2: // 出口は(1, 0.5);
                goal = new Vector2(1.01f, 0.5f);
                break;
            case 3: // 出口は(0.5, 0);
                goal = new Vector2(0.5f, -0.01f);
                break;
            case 4: // 出口は(0, 0.5);
                goal = new Vector2(-0.01f, 0.5f);
                break;
        }

        // 残りの距離を計算
        Vector2 vec = goal - Pos;
        // 正規化して進む距離を計算
        Vector2 vecNorm = vec.normalized;
        // 次の座標の計算
        moveMent = vecNorm * speed;

        // 次の座標が外に出ているかどうかを判定　超える場合はisNextをtrueにする
        Vector2 nextPos = Pos + moveMent;
        if (nextPos.x < 0 || nextPos.x > 1 || nextPos.y < 0 || nextPos.y > 1)
        {
            isNext = true;
        }
        else
        {
            isNext = false;
        }
    }


    // route2のパスについて
    public static void GetPathRoute2(Vector2 Pos, Vector2 BefPos, int inputNum, float speed, out Vector2 moveMent, out bool isNext, out bool isOut)
    {
        // 縦線のみ vecint →↑←↓の順に1234
        // 道1: 出入り口(0, 0.5), 出入り口(1, 0.5)
        isOut = false;
        isNext = false;
        Vector2 goal = new Vector2(0, 0);

        switch (inputNum)
        {
            case 1: // 出口は(1, 0.5);
                isOut = true;
                break;
            case 2:
                goal = new Vector2(0.5f, 1.1f);
                break;
            case 3: // 出口は(0, 0.5);
                isOut = true;
                break;
            case 4:
                goal = new Vector2(0.5f, -0.1f);
                break;
        }

        // 残りの距離を計算
        Vector2 vec = goal - Pos;
        // 正規化して進む距離を計算
        Vector2 vecNorm = vec.normalized;
        // 次の座標の計算
        moveMent = vecNorm * speed;

        // 次の座標が外に出ているかどうかを判定　超える場合はisNextをtrueにする
        Vector2 nextPos = Pos + moveMent;
        if (nextPos.x < 0 || nextPos.x > 1 || nextPos.y < 0 || nextPos.y > 1)
        {
            isNext = true;
        }
        else
        {
            isNext = false;
        }

    }

    // route3のパスについて
    public static void GetPathRoute3(Vector2 Pos, Vector2 BefPos, int inputNum, float speed, out Vector2 moveMent, out bool isNext, out bool isOut)
    {
        // vecint →↑←↓の順に1234
        //　十字の道 直線
        // 道1: 入口(0, 0.5), 出口(1, 0.5)
        // 道2: 入口(0.5, 0), 出口(0.5, 1)
        isOut = false;
        //　向きの計算
        Vector2 goal = new Vector2(0, 0);

        // Switch文で場合分け
        switch (inputNum)
        {
            case 1: // 出口は(1, 0.5);
                goal = new Vector2(1.01f, 0.5f);
                break;
            case 2: // 出口は(0.5, 1);
                goal = new Vector2(0.5f, 1.01f);
                break;
            case 3: // 出口は(0, 0.5);
                goal = new Vector2(-0.01f, 0.5f);
                break;
            case 4: // 出口は(0.5, 0);
                goal = new Vector2(0.5f, -0.01f);
                break;
        }

        // 残りの距離を計算
        Vector2 vec = goal - Pos;
        // 正規化して進む距離を計算
        Vector2 vecNorm = vec.normalized;
        // 次の座標の計算
        moveMent = vecNorm * speed;

        // 次の座標が外に出ているかどうかを判定　超える場合はisNextをtrueにする
        Vector2 nextPos = Pos + moveMent;
        float eqs = 1e-3f;
        if (nextPos.x < 0 + eqs || nextPos.x > 1 - eqs || nextPos.y < 0 + eqs || nextPos.y > 1 - eqs)
        {
            isNext = true;
        }
        else
        {
            isNext = false;
        }
    }

    // route4のパスについて
    public static void GetPathRoute4(Vector2 Pos, Vector2 BefPos, int inputNum, float speed, out Vector2 moveMent, out bool isNext, out bool isOut)
    {
        // vecint →↑←↓の順に1234
        // 道2: 出入り口(0.5, 1.0), 出入り口(1, 0.5)

        // 道1の場合斜めに進む
        // 道2の場合斜めに進む
        //　向きの計算
        isOut = false;
        isNext = false;
        Vector2 goal = new Vector2(0, 0);
        moveMent = new Vector2(0, 0);

        // Switch文で場合分け
        switch (inputNum)
        {
            case 1: // 出口は(0.5, 0);
                isOut = true;
                return;
            // break;
            case 2: // 出口は(0, 0.5);
                isOut = true;
                return;
            // break;
            case 3: // 出口は(0.5, 1);
                goal = new Vector2(0.5f, 1.01f);
                break;
            case 4: // 出口は(1, 0.5);
                goal = new Vector2(1.01f, 0.5f);
                break;
        }

        // 残りの距離を計算
        Vector2 vec = goal - Pos;
        // 正規化して進む距離を計算
        Vector2 vecNorm = vec.normalized;
        // 次の座標の計算
        moveMent = vecNorm * speed;

        // 次の座標が外に出ているかどうかを判定　超える場合はisNextをtrueにする
        Vector2 nextPos = Pos + moveMent;
        if (nextPos.x < 0 || nextPos.x > 1 || nextPos.y < 0 || nextPos.y > 1)
        {
            isNext = true;
        }
        else
        {
            isNext = false;
        }
    }



    // route5のパスについて
    public static void GetPathRoute5(Vector2 Pos, Vector2 BefPos, int inputNum, float speed, out Vector2 moveMent, out bool isNext, out bool isOut)
    {
        // vecint →↑←↓の順に1234
        // 道1: 出入り口(0, 0.5), 出入り口(0.5, 0)
        // 道2: 出入り口(0.5, 1.0), 出入り口(1, 0.5)

        // 道1の場合斜めに進む
        // 道2の場合斜めに進む
        //　向きの計算
        isOut = false;
        isNext = false;
        Vector2 goal = new Vector2(0, 0);


        // Switch文で場合分け
        switch (inputNum)
        {
            case 1: // 出口は(0.5, 0);
                goal = new Vector2(0.5f, -0.01f);
                break;
            case 2: // 出口は(0, 0.5);
                goal = new Vector2(-0.01f, 0.5f);
                break;
            case 3: // 出口は(0.5, 1);
                goal = new Vector2(0.5f, 1.01f);
                break;
            case 4: // 出口は(1, 0.5);
                goal = new Vector2(1.01f, 0.5f);
                break;
        }

        // 残りの距離を計算
        Vector2 vec = goal - Pos;
        // 正規化して進む距離を計算
        Vector2 vecNorm = vec.normalized;
        // 次の座標の計算
        moveMent = vecNorm * speed;

        // 次の座標が外に出ているかどうかを判定　超える場合はisNextをtrueにする
        Vector2 nextPos = Pos + moveMent;
        if (nextPos.x < 0 || nextPos.x > 1 || nextPos.y < 0 || nextPos.y > 1)
        {
            isNext = true;
        }
        else
        {
            isNext = false;
        }
    }

    // route6のパスについて
    public static void GetPathRoute6(Vector2 Pos, Vector2 BefPos, int inputNum, float speed, out Vector2 moveMent, out bool isNext, out bool isOut)
    {
        // 横線のみ vecint →↑←↓の順に1234
        // 道1: 出入り口(0, 0.5), 出入り口(1, 0.5)
        isOut = false;
        isNext = false;
        Vector2 goal = new Vector2(0, 0);
        moveMent = new Vector2(0, 0);

        switch (inputNum)
        {
            case 1: // 出口は(1, 0.5);
                goal = new Vector2(1.01f, 0.5f);
                break;
            case 2:
                isOut = true;
                return;
            // break;
            case 3: // 出口は(0, 0.5);
                goal = new Vector2(-0.01f, 0.5f);
                return;
            // break;
            case 4:
                isOut = true;
                break;
        }

        // 残りの距離を計算
        Vector2 vec = goal - Pos;
        // 正規化して進む距離を計算
        Vector2 vecNorm = vec.normalized;
        // 次の座標の計算
        moveMent = vecNorm * speed;

        // 次の座標が外に出ているかどうかを判定　超える場合はisNextをtrueにする
        Vector2 nextPos = Pos + moveMent;
        if (nextPos.x < 0 || nextPos.x > 1 || nextPos.y < 0 || nextPos.y > 1)
        {
            isNext = true;
        }
        else
        {
            isNext = false;
        }
    }
}
