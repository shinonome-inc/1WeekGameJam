using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodChildGenerator : MonoBehaviour
{
    public GameObject goodChildPrefab;

    public void GemerateGoodChildPrefab(float x, float y)
    {
        const float scale = 0.04f;
        GameObject go = Instantiate(goodChildPrefab) as GameObject;
        go.transform.position = new Vector2(x, y);
        go.transform.localScale = new Vector2(scale, scale);
    }

    void Start()
    {
        GemerateGoodChildPrefab(4.0f, 0.0f);
    }
}
