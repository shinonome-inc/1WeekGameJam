using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;


public class PositionValidater : MonoBehaviour
{
    // TilePath tilePath = new TilePath();
    public float tileSize = 2.7f;

    // 生成位置の検証
    public bool ValidateGenerationPosition(float x, float y, out float xOut, out float yOut)
    {

        Vector2 pos = new Vector2(x, y);
        Vector2 posNorm = TilePath.GetNormalizedPos(pos);

        // 座標番号を取得
        int col, row;
        TilePath.GetTileNumber(pos, out col, out row);
        string tileName = tilescript.GetStringArrayElement(col, row);
        if (tileName == "R0")
        {
            // R0の場合は生成しない
            xOut = x;
            yOut = y;
            return false;
        }

        // Debug.Log("col: " + col + " row: " + row + " tileName: " + tileName);

        // 0.2 ~ 0.8の範囲に生成していない場合は移動させる
        xOut = x;
        float xMoveDiff = 0.0f;
        if (posNorm.x < 0.2f)
        {
            xMoveDiff = 0.2f;
        }
        else if (posNorm.x > 0.8f)
        {
            xMoveDiff = -0.2f;
        }

        // Y座標
        yOut = y;
        float yMoveDiff = 0.0f;
        if (posNorm.y < 0.2f)
        {
            yMoveDiff = 0.2f;
        }
        else if (posNorm.y > 0.8f)
        {
            yMoveDiff = -0.2f;
        }

        // R6の場合、左下に生成されないようにする
        // if (tileName == "R6"　&& posNorm.x < 0.5f && posNorm.y < 0.5f)
        // {
        //     xMoveDiff += 0.5f;
        //     yMoveDiff += 0.5f;
        // }

        // 移動させる
        xOut += xMoveDiff * tileSize;
        yOut += yMoveDiff * tileSize;

        // Debug.Log("(x,y)" + x + " " + y + " (xOut,yOut)" + xOut + " " + yOut + " (posNorm.x, posNorm.y)" + posNorm.x + " " + posNorm.y);
        return true;
    }

}
