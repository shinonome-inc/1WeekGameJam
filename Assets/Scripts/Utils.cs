using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using System;
using Constants;

namespace Utils
{
    /// <summary>
    /// 座標に関するユーティリティクラス
    /// </summary>
    public static class CoordinateUtil
    {
        /// <summary>
        /// 画面内のランダムなX座標を生成するメソッド
        /// </summary>
        /// <returns></returns>
        public static float RandomPosX()
        {
            float posX = Random.Range(Coordinates.minX, Coordinates.maxX);
            return posX;
        }

        /// <summary>
        /// 画面内のランダムなY座標を生成するメソッド
        /// </summary>
        /// <returns></returns>
        public static float RandomPosY()
        {
            float posY = Random.Range(Coordinates.minY, Coordinates.maxY);
            return posY;
        }
    }
}
