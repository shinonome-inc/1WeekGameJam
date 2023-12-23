using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class GoodChildGenerator : MonoBehaviour
{
    public GameObject goodChildPrefab;

    public void GemerateGoodChild()
    {
        float x = CoordinateUtil.RandomPosX();
        float y = CoordinateUtil.RandomPosY();
        const float scale = 0.04f;
        GameObject go = Instantiate(goodChildPrefab) as GameObject;
        go.transform.position = new Vector2(x, y);
        go.transform.localScale = new Vector2(scale, scale);
    }

    void Start()
    {
        GemerateGoodChild();
    }
}
