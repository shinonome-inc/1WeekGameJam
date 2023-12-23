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
            const float generatorMinX = -8.0f;
            const float generatorMaxX = 8.0f;
            float posX = Random.Range(generatorMinX, generatorMaxX);
            return posX;
        }

        /// <summary>
        /// 画面内のランダムなY座標を生成するメソッド
        /// </summary>
        /// <returns></returns>
        public static float RandomPosY()
        {
            const float generatorMinY = -4.0f;
            const float generatorMaxY = 4.0f;
            float posY = Random.Range(generatorMinY, generatorMaxY);
            return posY;
        }
    }
}
