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
        public static float RandomPosX()
        {
            const float generatorMinX = -8.0f;
            const float generatorMaxX = 8.0f;
            float posX = Random.Range(generatorMinX, generatorMaxX);
            return posX;
        }

        public static float RandomPosY()
        {
            const float generatorMinY = -4.0f;
            const float generatorMaxY = 4.0f;
            float posY = Random.Range(generatorMinY, generatorMaxY);
            return posY;
        }
    }
}
